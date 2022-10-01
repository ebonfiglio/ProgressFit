namespace ProgressFit.Mobile.Views.Modules.Workout.Main;

public partial class WorkoutMainPage : ContentPage
{
	public WorkoutMainPage(WorkoutMainViewModel viewModel)
	{
        BindingContext = viewModel;

        InitializeComponent();
	}
}