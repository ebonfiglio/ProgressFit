using ProgressFit.Data.Entities;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services.Contracts
{
    public interface IGenericService<T, R, TKey>
    {
        Task<R> GetAsync(TKey id);
        Task<IEnumerable<R>> GetAllAsync();
        Task<IEnumerable<R>> FindAsync(Expression<Func<Diet, bool>> predicate);
        Task<R> AddAsync(T request);
        Task<R> UpdateAsync(T request);
        Task DeleteAsync(TKey id);
    }
}
