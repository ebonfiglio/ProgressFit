using AutoMapper;
using ProgressFit.Data;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services
{
    public class TosService : ITosService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public TosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TosResponse> GetCurrent()
        {
            return Task.Run(()=> new TosResponse());
        }
    }
}
