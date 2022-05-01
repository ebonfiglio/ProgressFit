using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class CalculationVariableType
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        public string Name { get; set; }

        [ForeignKey("DietMethod")]
        public Guid DietMethodId { get; set; }

        public virtual DietMethod DietMethod { get; set; }

        [ForeignKey("MacroNutrient")]
        public Guid MacroNutrientId { get; set; }

        public virtual MacroNutrient MacroNutrient { get; set; }

    }
}
