using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Shared.Responses
{
    public class AuthTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expires { get; set; }
    }
}
