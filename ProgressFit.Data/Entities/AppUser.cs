using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser(string userName) : base(userName)
        { 
        }
        public DateTime Created { get; set; }

        //[ForeignKey("Setting")]
        //public int SettingId { get; set; }
        //public virtual Setting Setting { get; set; }

        //[ForeignKey("Tos")]
        //public int TosId { get; set; }
        //public virtual Tos Tos { get; set; }

        //[ForeignKey("DietSetting")]
        //public int DietSettingId { get; set; }
        //public virtual DietSetting DietSetting { get; set; }
    }
}
