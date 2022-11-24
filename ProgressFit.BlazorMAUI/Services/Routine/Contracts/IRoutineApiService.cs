using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;

namespace ProgressFit.BlazorMAUI.Services.Routine.Contracts
{
    internal interface IRoutineApiService : IGenericApiService<RoutineRequest, RoutineResponse, ProgressFit.Shared.Entities.Routine, Guid>
    {
    }
}
