using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.BlazorMAUI.Services
{
    internal interface IGenericApiService<T, R, TEntity, TKey>
    {
        Task<R> GetAsync(TKey id);
        Task<IEnumerable<R>> GetAllAsync();
        Task<IEnumerable<R>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<R> AddAsync(T request);
        Task<R> UpdateAsync(T request);
        Task DeleteAsync(TKey id);

    }
}
