using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class MacroNutrientMultiplier
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        [ForeignKey("MacroNutrient")]
        public Guid MacroNutrientId { get; set; }

        public MacroNutrient MacroNutrient { get; set; }

        [ForeignKey("DietType")]
        public Guid DietTypeId { get; set; }

        public DietType DietType { get; set; }
    }
}
