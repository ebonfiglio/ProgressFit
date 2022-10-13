using ProgressFit.Mobile.ViewModels;

namespace ProgressFit.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;

            InitializeComponent();
        }
    }
}