using ProgressFit.Domain.Services;
using ProgressFit.Domain.Services.Contracts;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.MauiAppLib.Endpoints.Routine
{
    public class RoutineEndpoint
    {
        private readonly IRoutineService _routineService;
        public RoutineEndpoint(IRoutineService routineService)
        {
            _routineService= routineService;
        }
        public async Task<RoutineResponse> Create(RoutineRequest request)
        {
            RoutineResponse response = new();
            response = await _routineService.AddAsync(request);
            return response;
        }
    }
}
