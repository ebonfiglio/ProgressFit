using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgressFit.Shared.Models.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
