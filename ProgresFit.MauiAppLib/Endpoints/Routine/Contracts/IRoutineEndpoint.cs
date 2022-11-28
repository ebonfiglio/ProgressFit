using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.MauiAppLib.Endpoints.Routine.Contracts
{
    public interface IRoutineEndpoint
    {
        Task<RoutineResponse> Create(RoutineRequest request);
    }
}
