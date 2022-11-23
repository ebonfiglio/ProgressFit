using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class MuscleWorkRate
    {
        public Guid Id { get; set; }

        [ForeignKey("Muscle")]
        public Guid MuscleId { get; set; }
        public virtual Muscle Muscle { get; set; }

        [ForeignKey("WorkRate")]
        public Guid WorkRateId { get; set; }
        public virtual WorkRate WorkRate { get; set; }
    }
}
