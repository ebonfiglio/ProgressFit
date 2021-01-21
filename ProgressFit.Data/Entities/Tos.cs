using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class Tos
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public DateTime DateActive { get; set; }

        public bool Current { get; set; }

        public string Text { get; set; }
    }
}
