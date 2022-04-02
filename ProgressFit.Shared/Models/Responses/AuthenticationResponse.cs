using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Shared.Models.Responses
{
    public class AuthenticationResponse
    {
        public bool Succeeded { get; set; }
        public string Email { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public AuthTokenResponse Token { get; set; }
    }
}
