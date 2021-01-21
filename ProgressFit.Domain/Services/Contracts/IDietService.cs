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
    public interface IDietService
    {
        Task<DietResponse> GetAsync(int id);
        Task<List<DietResponse>> GetAllAsync();
        Task<List<DietResponse>> FindAsync(Expression<Func<Diet, bool>> predicate);
        Task<DietResponse> AddAsync(DietRequest request);
        Task<DietResponse> UpdateAsync(DietRequest request);
        Task DeleteAsync(int id);
    }
}
