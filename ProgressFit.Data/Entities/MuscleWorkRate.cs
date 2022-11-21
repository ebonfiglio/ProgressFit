using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    internal class MuscleWorkRate
    {
        public Guid Id { get; set; }

        [ForeignKey("Muscle")]
        public Guid MuscleId { get; set; }
        public Muscle Muscle { get; set; }

        [ForeignKey("WorkRate")]
        public Guid WorkRateId { get; set; }
        public Muscle WorkRate { get; set; }
    }
}
