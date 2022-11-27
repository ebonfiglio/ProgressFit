using ProgressFit.BlazorMAUI.Services.Routine.Contracts;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.BlazorMAUI.Services.Routine
{
    internal class RoutineApiServices : IRoutineApiService
    {
        public Task<RoutineResponse> AddAsync(RoutineRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoutineResponse>> FindAsync(Expression<Func<ProgressFit.Shared.Entities.Routine, bool>> predicate)
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
