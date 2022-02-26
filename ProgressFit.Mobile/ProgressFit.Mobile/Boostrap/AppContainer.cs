using Autofac;
using ProgressFit.Mobile.Services.Contracts;
using ProgressFit.Mobile.Services.General;
using ProgressFit.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgressFit.Mobile.Boostrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<LoginPageViewModel>();

            //services
            //builder.RegisterType<ConnectionService>().As<IConnectionService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            //builder.RegisterType<DialogService>().As<IDialogService>();
            //builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            
            //General
            //builder.RegisterType<AppRepository>().As<IAppRepository>();

            _container = builder.Build();

        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
