using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ProgressFit.Data;
using ProgressFit.Data.Entities;
using ProgressFit.Data.Repositories;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Shared.Helpers;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ILogger _logger;
        public AuthService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ILogger<AuthService> logger)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }
        public AuthToken GenerateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var expires = DateTime.UtcNow.AddSeconds(_appSettings.ExpiryTimeInSeconds);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim(ClaimTypes.Name, user.UserName.ToString())
                    }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _appSettings.Audience,
                Issuer = _appSettings.Issuer
            };
            var jwt = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(jwt);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            return new AuthToken
            {
                AccessToken = token,
                Expires = exp
            };
        }

        public async Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            AuthenticationResponse response = new AuthenticationResponse();
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is null)
            {
                response.Succeeded = false;
                return response;
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            response.Succeeded = result.Succeeded;
            if (!result.Succeeded) return response;

            AuthenticationResponse loginResponse = _mapper.Map<AuthenticationResponse>(user);
            loginResponse.Token = _mapper.Map<AuthTokenResponse>(GenerateToken(user));
            var refreshToken = _passwordHasher.HashPassword(user, Guid.NewGuid().ToString())
       .Replace("+", string.Empty)
       .Replace("=", string.Empty)
       .Replace("/", string.Empty);
            loginResponse.Token.RefreshToken = refreshToken;
            //await _unitOfWork.RefreshTokenRepository.Add(new RefreshToken { UserId = user.Id, Token = refreshToken });
            return loginResponse;
        }

        public async Task<AuthToken> RefreshAccessToken(string token)
        {
            var refreshToken = new RefreshToken(); //await _unitOfWork.RefreshTokenRepository.Get(token);
            if (refreshToken == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh token was revoked");
            }
            var user = await _userManager.FindByIdAsync(refreshToken.UserId);
            var jwt = GenerateToken(user);
            jwt.RefreshToken = refreshToken.Token;

            return jwt;
        }

        public async Task<AuthenticationResponse> Register(RegistrationRequest request)
        {

            var userToCreate = _mapper.Map<AppUser>(request);
            userToCreate.UserName = request.Email;
            userToCreate.Email = request.Email;
            userToCreate.Created = DateTime.UtcNow;
            var result = await _userManager.CreateAsync(userToCreate, request.Password);
            if (!result.Succeeded)
            {

                foreach (IdentityError error in result.Errors)
                {
                    //_logger.Log(error.Description);
                }
                AuthenticationResponse failedResponse = new AuthenticationResponse();
                failedResponse.Succeeded = result.Succeeded;
                return failedResponse;
            }
            AuthenticationResponse response = _mapper.Map<AuthenticationResponse>(userToCreate);
            response.Token = _mapper.Map<AuthTokenResponse>(GenerateToken(userToCreate));
            return response;

        }

        public async Task RevokeRefreshToken(string token)
        {
            var refreshToken = new RefreshToken();// await _unitOfWork.RefreshTokenRepository.Get(token);
            if (refreshToken == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh token was already revoked.");
            }
            refreshToken.Revoked = true;
        }
    }
}
