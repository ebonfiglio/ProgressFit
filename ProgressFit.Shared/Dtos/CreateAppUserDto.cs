using ProgressFit.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Shared.Dtos
{
    public class CreateAppUserDto
    {
        public CreateAppUserSettingRequest AppUserSettings { get; set; }

        public CreateAppUserRequest AppUser { get; set; }

        public bool Tos { get; set; }
    }
}
