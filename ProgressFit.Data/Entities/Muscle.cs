using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class Muscle
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Function")]
        public string FunctionId { get; set; }
        public Function Function { get; set; }
    }
}
