using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressFit.Data.Entities
{
    public class ActivityLevel
    {
        [Key]
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string ShortDisplayName { get; set; }

        public decimal Value { get; set; }

        [ForeignKey("DietMethod")]
        public Guid DietMethodId { get; set; }

        public DietMethod DietMethod { get; set; }

    }
}
