using AutoMapper;
using ProgressFit.Data;
using ProgressFit.Shared.Entities;
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
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public RoutineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RoutineResponse> AddAsync(RoutineRequest request)
        {
            Routine entity = _mapper.Map<Routine>(request);
            Routine result = await _unitOfWork.RoutineRepository.Add(entity);
            await _unitOfWork.RoutineRepository.SaveChanges();
            return _mapper.Map<RoutineResponse>(result);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoutineResponse>> FindAsync(Expression<Func<Routine, bool>> predicate)
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
