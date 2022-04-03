
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgressFit.Shared.Models.Requests
{
    public class RegistrationRequest
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
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }

        [Required, Range(typeof(bool), "true", "true", ErrorMessage = "Accepting terms is required")]
        public bool AcceptTos { get; set; }

        [Required]
        public string FirstName { get; set; }
    }
}
