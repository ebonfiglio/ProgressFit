using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Domain.Services.Contracts
{
    public interface IRoutineService : IGenericService<RoutineRequest, RoutineResponse, Guid>
    {
    }
}
