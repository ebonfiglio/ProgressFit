using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class DietMultipler
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }

        [ForeignKey("MultiplerType")]
        public Guid MultiplerTypeId { get; set; }

        public MultiplerType MultiplerType { get; set; }

        [ForeignKey("Sex")]
        public Guid SexId { get; set; }

        public Sex Sex { get; set; }

        [ForeignKey("DietType")]
        public Guid DietTypeId { get; set; }

        public DietType DietType { get; set; }
    }
}
