using CommunityToolkit.Maui;
using ProgressFit.Mobile.Pages.Modules.Workout.Form;
using ProgressFit.Mobile.Pages.Modules.Workout.Main;
using ProgressFit.Mobile.Services.Navigation;
using ProgressFit.Mobile.ViewModels;

namespace ProgressFit.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();



            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("hinted-ElaineSans-Regular", "HintedElaineSansRegular");
                fonts.AddFont("hinted-ElaineSans-SemiBold", "HintedElaineSansSemiBold");
            }).UseMauiCommunityToolkit()
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews();
            return builder.Build();
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
            mauiAppBuilder.Services.AddTransient<WorkoutMainPageModel>();
            mauiAppBuilder.Services.AddTransient<RoutineFormPageModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<WorkoutMainPage>();
            mauiAppBuilder.Services.AddTransient<RoutineFormPage>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            return mauiAppBuilder;
        }
    }
}