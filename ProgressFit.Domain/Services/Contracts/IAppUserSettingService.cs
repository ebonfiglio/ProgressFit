using ProgressFit.Data.Entities;
using ProgressFit.Shared.Requests;
using ProgressFit.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services.Contracts
{
    public interface IAppUserSettingService
    {
        Task<AppUserSettingResponse> GetAsync(int id);
        Task<List<AppUserSettingResponse>> GetAllAsync();
        Task<List<AppUserSettingResponse>> FindAsync(Expression<Func<AppUserSetting, bool>> predicate);
        Task<AppUserSettingResponse> AddAsync(AppUserSettingRequest request);
        Task<AppUserSettingResponse> UpdateAsync(AppUserSettingRequest request);
        Task DeleteAsync(int id);
    }
}
