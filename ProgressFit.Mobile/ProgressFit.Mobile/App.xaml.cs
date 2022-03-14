using ProgressFit.Mobile.Boostrap;
using ProgressFit.Mobile.Pages;
using ProgressFit.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgressFit.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //InitializeApp();
            MainPage = new NavigationPage(new LoginPage());
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
