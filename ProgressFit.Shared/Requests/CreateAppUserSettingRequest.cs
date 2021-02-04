using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgressFit.Shared.Requests
{
    public class CreateAppUserSettingRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public decimal ActivityLevel { get; set; }
        [Required]
        [Range(3, 75, ErrorMessage = "Please enter valid Height")]
        public decimal BodyFat { get; set; }
        public int BMR { get; set; }
        [Required]
        [Range(24, 144, ErrorMessage = "Please enter valid Height")]
        public int Height { get; set; }
        [Required]
        [Range(0, 800, ErrorMessage = "Please enter valid Weight")]
        public decimal Weight { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
    }
}
