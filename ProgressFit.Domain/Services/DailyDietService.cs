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
    public class DailyDietService : IDailyDietService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DailyDietService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DailyDietResponse> AddAsync(DailyDietRequest request)
        {
            var entity = _mapper.Map<DailyDiet>(request);
            var result = await _unitOfWork.DailyDietRepository.Add(entity);
            await _unitOfWork.DietRepository.SaveChanges();
            return _mapper.Map<DailyDietResponse>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.DailyDietRepository.Get(id);
            await _unitOfWork.DailyDietRepository.Delete(entity);
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<DailyDietResponse>> FindAsync(Expression<Func<DailyDiet, bool>> predicate)
        {
            var entity = await _unitOfWork.DailyDietRepository.Find(predicate);
            return _mapper.Map<List<DailyDietResponse>>(entity.ToList());
        }

        public async Task<List<DailyDietResponse>> GetAllAsync()
        {
            var entityList = await _unitOfWork.DailyDietRepository.All();
            return _mapper.Map<List<DailyDietResponse>>(entityList);
        }

        public async Task<DailyDietResponse> GetAsync(int id)
        {
            var entity = await _unitOfWork.DailyDietRepository.Get(id);
            if (entity is null) return null;
            return _mapper.Map<DailyDietResponse>(entity);
        }

        public async Task<DailyDietResponse> UpdateAsync(DailyDietRequest request)
        {
            var existingItem = await _unitOfWork.DailyDietRepository.Get(request.Id);
            if (existingItem == null) return null;


            var entity = _mapper.Map(request, existingItem);
            var result = await _unitOfWork.DailyDietRepository.Update(entity);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<DailyDietResponse>(result);
        }
    }
}
