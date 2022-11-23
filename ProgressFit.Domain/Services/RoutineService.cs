using ProgressFit.Data.Entities;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services
{
    public class RoutineService : IRoutineService
    {
        public Task<RoutineResponse> AddAsync(RoutineRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoutineResponse>> FindAsync(Expression<Func<Diet, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoutineResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoutineResponse> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RoutineResponse> UpdateAsync(RoutineRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
