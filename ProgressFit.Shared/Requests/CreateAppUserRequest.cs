
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgressFit.Shared.Requests
{
    public class CreateAppUserRequest
    {
       
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Compare(nameof(Email), ErrorMessage = "Email mismatch")]
        public string ConfirmEmail { get; set; }

        [Required]
        [MinLength(6)]
        [Compare(nameof(Email), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
    }
}
