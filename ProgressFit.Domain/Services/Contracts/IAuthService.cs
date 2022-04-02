using Microsoft.IdentityModel.JsonWebTokens;
using ProgressFit.Data.Entities;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services.Contracts
{
    public interface IAuthService
    {
        AuthToken GenerateToken(AppUser user);
        Task<AuthToken> RefreshAccessToken(string token);
        Task RevokeRefreshToken(string token);

        Task<AuthenticationResponse> Login(AuthenticationRequest request);

        Task<AuthenticationResponse> Register(RegistrationRequest request);
    }
}
