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
    public class AppUserSettingService : IAppUserSettingService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AppUserSettingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AppUserSettingResponse> AddAsync(CreateAppUserSettingRequest request)
        {
            var entity = _mapper.Map<AppUserSetting>(request);
            var result = await _unitOfWork.AppUserSettingRepository.Add(entity);
            await _unitOfWork.AppUserSettingRepository.SaveChanges();
            return _mapper.Map<AppUserSettingResponse>(result);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.AppUserSettingRepository.Get(id);
            await _unitOfWork.AppUserSettingRepository.Delete(entity);
            await _unitOfWork.AppUserSettingRepository.SaveChanges();
        }

        public async Task<List<AppUserSettingResponse>> FindAsync(Expression<Func<AppUserSetting, bool>> predicate)
        {
            var entity = await _unitOfWork.AppUserSettingRepository.Find(predicate);
            return _mapper.Map<List<AppUserSettingResponse>>(entity.ToList());
        }

        public async Task<List<AppUserSettingResponse>> GetAllAsync()
        {
            var entityList = await _unitOfWork.AppUserSettingRepository.All();
            return _mapper.Map<List<AppUserSettingResponse>>(entityList);
        }

        public async Task<AppUserSettingResponse> GetAsync(int id)
        {
            var entity = await _unitOfWork.AppUserSettingRepository.Get(id);
            if (entity is null) return null;
            return _mapper.Map<AppUserSettingResponse>(entity);
        }

        public async Task<AppUserSettingResponse> UpdateAsync(AppUserSettingRequest request)
        {
            var existingItem = await _unitOfWork.AppUserSettingRepository.Get(request.Id);
            if (existingItem == null) return null;


            var entity = _mapper.Map(request, existingItem);
            var result = await _unitOfWork.AppUserSettingRepository.Update(entity);
            await _unitOfWork.AppUserSettingRepository.SaveChanges();

            return _mapper.Map<AppUserSettingResponse>(result);
        }
    }
}
