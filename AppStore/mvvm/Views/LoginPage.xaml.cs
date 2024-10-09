using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class LoginPage : ContentPage
{
    private LoginViewModel viewModel;

    public LoginPage()
    {
        InitializeComponent(); // Debe estar antes de BindingContext
        BindingContext = viewModel = new LoginViewModel();
    }
}
