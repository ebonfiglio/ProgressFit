using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class Session
    {
        public Guid Id { get; set; }

        [ForeignKey("Routine")]
        public Guid RoutineId { get; set; }
        public virtual Routine Routine { get; set; }

        [ForeignKey("Workout")]
        public Guid WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }

        public virtual IEnumerable<SessionExercise> SessionExercise { get; set; }


    }
}
