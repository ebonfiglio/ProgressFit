using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Set> Sets { get; set; }

        public virtual IEnumerable<MuscleWorkRate> MuscleWorkRates { get; set; }

        [ForeignKey("Function")]
        public Guid FunctionId { get; set; }

        public virtual Function Function { get; set; }
    }
}
