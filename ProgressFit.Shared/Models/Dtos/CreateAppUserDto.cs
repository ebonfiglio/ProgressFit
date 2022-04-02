using ProgressFit.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Shared.Models.Dtos
{
    public class CreateAppUserDto
    {
        public CreateAppUserSettingRequest AppUserSettings { get; set; }

        public RegistrationRequest AppUser { get; set; }

        public bool Tos { get; set; }
    }
}
