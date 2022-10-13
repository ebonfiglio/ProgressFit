namespace ProgressFit.Mobile.Views.Modules.Workout.Main;

public partial class WorkoutMainView : ContentPage
{
	public WorkoutMainView(WorkoutMainViewModel viewModel)
	{
        BindingContext = viewModel;

        InitializeComponent();
	}
}