
namespace ProgressFit.Mobile.Pages.Modules.Workout.Form;

public partial class RoutineFormPage : ContentPage
{
	public RoutineFormPage(RoutineFormPageModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
	}
}