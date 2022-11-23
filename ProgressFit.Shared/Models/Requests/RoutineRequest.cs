using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Models.Requests
{
    public class RoutineRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<WorkoutRequest> Workouts { get; set; }
    }
}
