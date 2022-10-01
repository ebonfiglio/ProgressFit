using CommunityToolkit.Maui;
using ProgressFit.Mobile.Views.Modules.Workout.Main;
using ProgressFit.Mobile.Services.Navigation;

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
            mauiAppBuilder.Services.AddTransient<WorkoutMainViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<WorkoutMainPage>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            return mauiAppBuilder;
        }
    }
}