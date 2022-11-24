using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class CalculationVariable
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("CalculationVariableType")]
        public Guid CalculationVariableTypeId { get; set; }

        public virtual CalculationVariableType CalculationVariableType { get; set; }

        public decimal Value { get; set; }

    }
}
