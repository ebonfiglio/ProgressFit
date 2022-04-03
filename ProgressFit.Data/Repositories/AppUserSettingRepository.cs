using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Repositories
{
    public class AppUserSettingRepository : GenericRepository<Setting>
    {
        public AppUserSettingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
