using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    /// <summary>
    /// Calorie, Protien, Carbohydrate, Fat...
    /// </summary>
    public class MacroNutrient
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

    }
}
