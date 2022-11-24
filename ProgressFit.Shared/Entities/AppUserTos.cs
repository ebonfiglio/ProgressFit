using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Shared.Entities
{
    public class AppUserTos
    {
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public Guid AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public int TosId { get; set; }

        public DateTime Accepted { get; set; }
    }
}
