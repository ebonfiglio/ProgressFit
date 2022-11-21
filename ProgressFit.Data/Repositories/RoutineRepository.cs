using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Repositories
{
    public class RoutineRepository : GenericRepository<Routine>
    {
        public RoutineRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
