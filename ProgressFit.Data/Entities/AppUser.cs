using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser(string userName) : base(userName)
        { 
        }
        public DateTime Created { get; set; }

        [ForeignKey("Setting")]
        public int SettingId { get; set; }
        public virtual AppUserSetting Setting { get; set; }
    }
}
