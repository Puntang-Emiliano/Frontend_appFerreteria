using AppStore.mvvm.Views;
using AppStore.mvvm.ViewModels;

namespace AppStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Instanciar el LoginViewModel y pasarlo a la LoginPage
            var loginViewModel = new LoginViewModel();
            MainPage = new NavigationPage(new LoginPage(loginViewModel));
        }
    }
}
