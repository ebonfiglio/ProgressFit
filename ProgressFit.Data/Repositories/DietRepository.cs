using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Repositories
{
    public class DietRepository : GenericRepository<Diet>
    {
        public DietRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
