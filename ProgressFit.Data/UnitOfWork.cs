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

        IRepository<AppUserSetting> AppUserSettingRepository { get; }

        IRepository<RefreshToken> RefreshTokenRepository { get; }

        IRepository<Tos> TosRepository { get; }

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

        private IRepository<AppUserSetting> appUserSettingRepository;
        public IRepository<AppUserSetting> AppUserSettingRepository
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

        private IRepository<RefreshToken> refreshTokenRepository;
        public IRepository<RefreshToken> RefreshTokenRepository
        {
            get
            {
                if (refreshTokenRepository == null)
                {
                    refreshTokenRepository = new RefreshTokenRepository(context);
                }
                return refreshTokenRepository;
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

        public virtual async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
