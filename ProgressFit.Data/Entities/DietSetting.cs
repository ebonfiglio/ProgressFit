using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class DietSetting
    {
        [Key]
        public int Id { get; set; }
        public string Sex { get; set; }
        public decimal ActivityLevel { get; set; }
        public decimal BodyFat { get; set; }
        public int BMR { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }

        public DateTime BirthDay { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
