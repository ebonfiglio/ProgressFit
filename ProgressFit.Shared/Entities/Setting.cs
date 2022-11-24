using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Shared.Entities
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [ForeignKey("AppUser")]
        public Guid AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }


    }
}
