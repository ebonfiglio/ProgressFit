using ProgressFit.Data.Entities;
using ProgressFit.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data
{
    public interface IUnitOfWork
    {
        IRepository<Diet> DietRepository { get; }

        IRepository<DailyDiet> DailyDietRepository { get; }

        IRepository<Setting> AppUserSettingRepository { get; }

        IRepository<Tos> TosRepository { get; }

        IRepository<Routine> RoutineRepository { get; }

        Task SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private IRepository<Diet> dietRepository;
        public IRepository<Diet> DietRepository
        {
            get
            {
                if (dietRepository == null)
                {
                    dietRepository = new DietRepository(context);
                }
                return dietRepository;
            }
        }

        private IRepository<DailyDiet> dailyDietRepository;
        public IRepository<DailyDiet> DailyDietRepository
        {
            get
            {
                if (dailyDietRepository == null)
                {
                    dailyDietRepository = new DailyDietRepository(context);
                }
                return dailyDietRepository;
            }
        }

        private IRepository<Setting> appUserSettingRepository;
        public IRepository<Setting> AppUserSettingRepository
        {
            get
            {
                if (appUserSettingRepository == null)
                {
                    appUserSettingRepository = new AppUserSettingRepository(context);
                }
                return appUserSettingRepository;
            }
        }

        private IRepository<Tos> tosRepository;
        public IRepository<Tos> TosRepository
        {
            get
            {
                if (tosRepository == null)
                {
                    tosRepository = new TosRepository(context);
                }
                return tosRepository;
            }
        }

        private IRepository<Routine> routineRepository;
        public IRepository<Routine> RoutineRepository
        {
            get
            {
                if (routineRepository == null)
                {
                    routineRepository = new RoutineRepository(context);
                }
                return routineRepository;
            }
        }

        public virtual async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
