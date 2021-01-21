using Microsoft.IdentityModel.JsonWebTokens;
using ProgressFit.Data.Entities;
using ProgressFit.Shared.Requests;
using ProgressFit.Shared.Responses;
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

        Task<AuthenticationResponse> Register(CreateAppUserRequest request);
    }
}
