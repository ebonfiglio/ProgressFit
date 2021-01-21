using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Data.Repositories
{
    public class AppUserSettingRepository : GenericRepository<AppUserSetting>
    {
        public AppUserSettingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
