using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class Diet
    {
        [Key]
        public Guid Id { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("AppUser")]
        public Guid AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<DailyDiet> DailyDiet { get; set; }

        public virtual ICollection<MacroNutrient> MacroNutrients { get; set; }
    }
}
