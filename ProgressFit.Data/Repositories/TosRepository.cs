using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Repositories
{
    public class TosRepository : GenericRepository<Tos>
    {
        public TosRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
