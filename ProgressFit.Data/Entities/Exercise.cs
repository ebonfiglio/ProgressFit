using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Set> Sets { get; set; }

        public IEnumerable<MuscleWorkRate> MuscleWorkRates { get; set; }

        [ForeignKey("Function")]
        public Guid FunctionId { get; set; }

        public Function Function { get; set; }
    }
}
