using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views
{
    public partial class HomePage : ContentPage
    {
    
        public HomePage(HomeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; 
        }

     
        public HomePage()
        {
            InitializeComponent();
        }
    }
}
