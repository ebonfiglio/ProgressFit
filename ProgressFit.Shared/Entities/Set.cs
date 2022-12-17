using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class Set
    {
        public Guid Id { get; set; }

        public decimal Weight { get; set; }
        public int Reps { get; set; }
    }
}
