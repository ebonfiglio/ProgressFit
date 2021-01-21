using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressFit.API.Helpers
{
    public class TokenManager : ITokenManager
    {
        //private readonly IDistributedCache _cache;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<AppSettings> _jwtOptions;

        public TokenManager(IMemoryCache cache,
                IHttpContextAccessor httpContextAccessor,
                IOptions<AppSettings> jwtOptions
            )
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptions;
        }

        public async Task<bool> IsCurrentActiveToken()
            => await IsActiveAsync(GetCurrentAsync());

        public async Task DeactivateCurrentAsync()
            => await DeactivateAsync(GetCurrentAsync());

        public async Task<bool> IsActiveAsync(string token)
            => await Task.Run(()=>_cache.Get(token) == null);

        public async Task DeactivateAsync(string token)
            => await Task.Run(()=>_cache.Set<string>(token,
                "deactivated", 
                        TimeSpan.FromMinutes(_jwtOptions.Value.ExpiryMinutes)
                ));

        private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccessor
                .HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }


    }
}

