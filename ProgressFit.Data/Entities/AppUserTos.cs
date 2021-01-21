using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Entities
{
    public class AppUserTos
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }

        public int TosId { get; set; }

        public DateTime Accepted { get; set; }

    }
}
