﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class Workout
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
