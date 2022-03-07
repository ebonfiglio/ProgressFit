using ProgressFit.Mobile.Boostrap;
using ProgressFit.Mobile.Pages;
using ProgressFit.Mobile.Services.Contracts;
using ProgressFit.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgressFit.Mobile.Services.General
{
    internal class NavigationService : INavigationService
    {
        //private readonly IAuthenticationService _authenticationService;
        private readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()//IAuthenticationService authenticationService)
        {
            //_authenticationService = authenticationService;
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
           // await NavigateToAsync<MainViewModel>();
            if (false)//_authenticationService.IsUserAuthenticated())
            {
                //await NavigateToAsync<HomeViewModel>();
            }
            else
            {
                await NavigateToAsync<LoginPageViewModel>();
            }

        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public async Task ClearBackStack()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainPage mainPage)
            {
                await mainPage.Navigation.PopAsync();//.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MainPage mainPage)
            {
                //mainPage.Detail.Navigation.RemovePage(
                //    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
                mainPage.Navigation.RemovePage(
                  mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task PopToRootAsync()
        {
            if (CurrentApplication.MainPage is MainPage mainPage)
            {
                await mainPage.Navigation.PopToRootAsync();//.Detail.Navigation.PopToRootAsync();
            }
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            //if (page is MainPage || page is RegistrationPage)
            //{
            //    CurrentApplication.MainPage = page;
            //}
            //else if (page is LoginPage)
            //{
            //    CurrentApplication.MainPage = page;
            //}
            //else if (CurrentApplication.MainPage is MainPage)
            //{
            //    var mainPage = CurrentApplication.MainPage as MainPage;

            //    if (mainPage.Detail is NavigationPage navigationPage)
            //    {
            //        var currentPage = navigationPage.CurrentPage;

            //        if (currentPage.GetType() != page.GetType())
            //        {
            //            await navigationPage.PushAsync(page);
            //        }
            //    }
            //    else
            //    {
            //        navigationPage = new NavigationPage(page);
            //        mainPage.Detail = navigationPage;
            //    }

            //    mainPage.IsPresented = false;
            //}
            //else
            //{
            //    var navigationPage = CurrentApplication.MainPage as NavigationPage;

            //    if (navigationPage != null)
            //    {
            //        await navigationPage.PushAsync(page);
            //    }
            //    else
            //    {
            //        CurrentApplication.MainPage = new NavigationPage(page);
            //    }
            //}

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;

            ViewModelBase viewModel = AppContainer.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(LoginPageViewModel), typeof(LoginPage));
        }
    }
}
