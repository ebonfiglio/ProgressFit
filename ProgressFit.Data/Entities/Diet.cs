using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Protien { get; set; }
        public int Fat { get; set; }
        public int Carb { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarbPreference { get; set; }

        [ForeignKey("AppUser")]
        public Guid AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        [ForeignKey("Goal")]
        public Guid GoalId { get; set; }
        public Goal Goal { get; set; }

        public virtual ICollection<DailyDiet> DailyDiet { get; set; }
    }
}
