﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class DietGoal
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
