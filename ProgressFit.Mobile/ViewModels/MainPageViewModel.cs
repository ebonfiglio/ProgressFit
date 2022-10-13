using ProgressFit.Mobile.Services.Navigation;
using ProgressFit.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ProgressFit.Mobile.Views.Modules.Workout.Main;

namespace ProgressFit.Mobile.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        [RelayCommand]
        private async Task OnWorkoutBtnClicked()
        {
            await NavigationService.NavigateToAsync(nameof(WorkoutMainView));
        }
    }
}
