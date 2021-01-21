using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using ProgressFit.API.Helpers;
using ProgressFit.Data.Entities;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Shared.Dtos;
using ProgressFit.Shared.Requests;
using ProgressFit.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly ITokenManager _tokenManager;
        private readonly IAppUserSettingService _appUserSettingService;
        public AuthController(IOptions<AppSettings> appSettings, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAuthService authService, ITokenManager tokenManager, IAppUserSettingService appUserSettingService)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _authService = authService;
            _tokenManager = tokenManager;
            _appUserSettingService = appUserSettingService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CreateAppUserDto request)
        {
            try
            {
                if (!ModelState.IsValid || request == null)
                {
                    return new BadRequestObjectResult(new { Message = "User Registration Failed" });
                }

                var result = await _authService.Register(request.AppUser);
                if (!result.Succeeded) return new BadRequestObjectResult(new{Message = "User Registration Failed"});
                var appUserSettingResult = await _appUserSettingService.AddAsync(request.AppUserSettings);
                if (appUserSettingResult is null){  
                    //log error ;
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            try
            {
                var result = await _authService.Login(request);
                if (!result.Succeeded) return Unauthorized();

                return Ok(result);
            }
            catch (Exception ex)
            {
                //log ex
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOff()
        {
            try
            {
                await _signInManager.SignOutAsync();
                await _tokenManager.DeactivateCurrentAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                //log ex
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
