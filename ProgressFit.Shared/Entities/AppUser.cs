using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Shared.Entities
{
    public class AppUser 
    {
        //public AppUser(string userName) : base(userName)
        //{ 
        //}
        //public DateTime Created { get; set; }

        //[ForeignKey("Setting")]
        //public int SettingId { get; set; }
        //public virtual Setting Setting { get; set; }

        //[ForeignKey("Tos")]
        //public int TosId { get; set; }
        //public virtual Tos Tos { get; set; }

        //[ForeignKey("DietSetting")]
        //public int DietSettingId { get; set; }
        //public virtual DietSetting DietSetting { get; set; }

        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
