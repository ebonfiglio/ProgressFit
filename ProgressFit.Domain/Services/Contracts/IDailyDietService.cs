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
    public interface IDailyDietService
    {
        Task<DailyDietResponse> GetAsync(int id);
        Task<List<DailyDietResponse>> GetAllAsync();
        Task<List<DailyDietResponse>> FindAsync(Expression<Func<DailyDiet, bool>> predicate);
        Task<DailyDietResponse> AddAsync(DailyDietRequest request);
        Task<DailyDietResponse> UpdateAsync(DailyDietRequest request);
        Task DeleteAsync(int id);
    }
}
