using CommunityToolkit.Mvvm.Input;
using ProgressFit.Mobile.Pages.Modules.Workout.Form;
using ProgressFit.Mobile.Services.Navigation;
using ProgressFit.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Mobile.Pages.Modules.Workout.Main
{
    public partial class WorkoutMainPageModel : ViewModelBase
    {
        public WorkoutMainPageModel(INavigationService navigationService) : base(navigationService)
        {
        }

        [RelayCommand]
        private async Task OnNewRoutineBtnClicked()
        {
            await NavigationService.NavigateToAsync(nameof(RoutineFormPage));
        }
    }
}
