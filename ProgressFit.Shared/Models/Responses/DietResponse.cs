using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Shared.Models.Responses
{
    public class DietResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Calories { get; set; }
        public int Protien { get; set; }
        public int Fat { get; set; }
        public int Carb { get; set; }
        public DateTime StartingDate { get; set; }
        public int AppUserId { get; set; }
        public string CarbPreference { get; set; }
    }
}
