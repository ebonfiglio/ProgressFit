namespace ProgressFit.Mobile.Pages.Modules.Workout.Main;

public partial class WorkoutMainPage : ContentPage
{
	public WorkoutMainPage(WorkoutMainPageModel viewModel)
	{
        BindingContext = viewModel;

        InitializeComponent();
	}
}