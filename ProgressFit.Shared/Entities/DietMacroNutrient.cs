using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class DietMacroNutrient
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Diet")]
        public Guid DietId { get; set; }

        public virtual Diet Diet { get; set; }

        [ForeignKey("MacroNutrient")]
        public Guid MacroNutrientd { get; set; }

        public virtual MacroNutrient MacroNutrient { get; set; }

        public int Value { get; set; }
    }
}
