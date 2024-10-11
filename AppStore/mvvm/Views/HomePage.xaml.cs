using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views
{
    public partial class HomePage : ContentPage
    {
        // Constructor que recibe un HomeViewModel
        public HomePage(HomeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; // Establece el BindingContext a viewModel
        }

        // Constructor sin parámetros (puedes mantenerlo si lo necesitas)
        public HomePage()
        {
            InitializeComponent();
        }
    }
}
