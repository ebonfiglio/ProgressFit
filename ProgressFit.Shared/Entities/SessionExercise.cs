using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Shared.Entities
{
    public class SessionExercise
    {
        public Guid Id { get; set; }

        [ForeignKey("Session")]
        public Guid SessionId { get; set; }

        public virtual Session Session { get; set; }

        [ForeignKey("Exercise")]
        public Guid ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual IEnumerable<Set> Sets { get; set; }
    }
}
