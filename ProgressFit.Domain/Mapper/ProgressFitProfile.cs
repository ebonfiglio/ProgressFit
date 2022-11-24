using AutoMapper;
using ProgressFit.Shared.Entities;
using ProgressFit.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Domain.Mapper
{
    public class ProgressFitProfile : Profile
    {
        public ProgressFitProfile()
        {
            CreateMap<RegistrationRequest, AppUser>().ReverseMap();
            CreateMap<CreateAppUserSettingRequest, Setting>().ReverseMap();
            CreateMap<RoutineRequest, Routine>().ReverseMap();
        }
       
    }
}
