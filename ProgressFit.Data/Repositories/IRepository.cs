using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Get(int id);
        Task<T> Get(string token);
        Task<T> GetByUserId(string userId);
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Delete(T entity);
        Task SaveChanges();
    }
}
