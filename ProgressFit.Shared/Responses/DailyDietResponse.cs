using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Shared.Responses
{
    public class DailyDietResponse
    {
        public int DailyDietId { get; set; }
        public int DietId { get; set; }
        public int PfAccountId { get; set; }
        public int DailyCals { get; set; }
        public int DailyProtien { get; set; }
        public int DailyFat { get; set; }
        public int DailyCarbs { get; set; }
    }
}
