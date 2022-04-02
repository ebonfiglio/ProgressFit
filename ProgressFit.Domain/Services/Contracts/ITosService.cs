using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services.Contracts
{
    public interface ITosService
    {
        Task<TosResponse> GetCurrent();
    }
}
