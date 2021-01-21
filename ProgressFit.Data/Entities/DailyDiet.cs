using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class DailyDiet
    {
        public int DailyDietId { get; set; }

        [ForeignKey("Diet")]
        public int DietId { get; set; }
        public int PfAccountId { get; set; }
        public int DailyCals { get; set; }
        public int DailyProtien { get; set; }
        public int DailyFat { get; set; }
        public int DailyCarbs { get; set; }
        public DateTime Date { get; set; }

        public virtual Diet Diet { get; set; }
    }
}
