using AutoMapper;
using ProgressFit.Data;
using ProgressFit.Data.Entities;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Shared.Requests;
using ProgressFit.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services
{
    public class DietService : IDietService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DietService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DietResponse> AddAsync(DietRequest request)
        {
            var entity = _mapper.Map<Diet>(request);
            var result = await _unitOfWork.DietRepository.Add(entity);
            await _unitOfWork.SaveChanges();
            return _mapper.Map<DietResponse>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.DietRepository.Get(id);
            await _unitOfWork.DietRepository.Delete(entity);
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<DietResponse>> FindAsync(Expression<Func<Diet, bool>> predicate)
        {
            var entity = await _unitOfWork.DietRepository.Find(predicate);
            return _mapper.Map<List<DietResponse>>(entity.ToList());
        }

        public async Task<List<DietResponse>> GetAllAsync()
        {
            var entityList = await _unitOfWork.DietRepository.All();
            return _mapper.Map<List<DietResponse>>(entityList);
        }

        public async Task<DietResponse> GetAsync(int id)
        {
            var entity = await _unitOfWork.DietRepository.Get(id);
            if (entity is null) return null;
            return _mapper.Map<DietResponse>(entity);
        }

        public async Task<DietResponse> UpdateAsync(DietRequest request)
        {
            var existingItem = await _unitOfWork.DietRepository.Get(request.Id);
            if (existingItem == null) return null;


            var entity = _mapper.Map(request, existingItem);
            var result = await _unitOfWork.DietRepository.Update(entity);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<DietResponse>(result);
        }
    }
}
