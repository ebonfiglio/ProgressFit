using MvvmHelpers;
using ProgressFit.Mobile.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Mobile.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        public INavigationService NavigationService { get; private set; }
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
