using Microsoft.AspNetCore.Components;
using ProgressFit.MauiAppLib.Endpoints.Routine.Contracts;
using ProgressFit.Shared.Models.Requests;
using ProgressFit.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.BlazorMAUI.Pages.Routine.Builder
{
     public class RoutineBuilderViewModel : ComponentBase
    {
        [Inject]
        public IRoutineEndpoint RoutineEndpoint { get; set; }

        public RoutineRequest Routine { get; set; } = new();

        [Parameter]
        public Guid? RoutineId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //get routine if ID provided...
            //Guid.TryParse(RoutineId, out var routineId);

            if (RoutineId is not null)
            {
                //Routine = await ExpenseService.GetExpenseById(int.Parse(ExpenseId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            //if Id save, if no ID create...
            await create();
        }

        private async Task<RoutineResponse> create()
        {
            return await RoutineEndpoint.Create(Routine);
        }
    }
}
