using AutoMapper;
using ProgressFit.Data.Entities;
using ProgressFit.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Domain.Mapper
{
    public class ProgressFitProfile : Profile
    {
        public ProgressFitProfile()
        {
                CreateMap<CreateAppUserRequest, AppUser>().ReverseMap();
            CreateMap<CreateAppUserSettingRequest, AppUserSetting>().ReverseMap();
        }
       
    }
}
