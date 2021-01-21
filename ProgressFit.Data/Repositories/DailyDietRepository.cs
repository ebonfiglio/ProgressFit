using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Repositories
{
    public class DailyDietRepository : GenericRepository<DailyDiet>
    {
        public DailyDietRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
