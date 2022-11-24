using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class DietMethod
    {
        [Key]
        public Guid Id { get; set; }

        public string DisplayName { get; set; }
    }
}
