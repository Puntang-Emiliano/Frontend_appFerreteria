using AppStore.mvvm.Models;
using AppStore.mvvm.Views;
using AppStore.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace AppStore.mvvm.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string nombre = Transport.nombre;

        // Comandos para la navegación
        [RelayCommand]
        public async Task GoToHomePage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HomePage(this));  // Navega a HomePage
        }

        [RelayCommand]
        public async Task GoToUsuariosPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuariosPage(new UsuariosViewModel(new ApiService())));  // Navega a UsuariosPage
        }

        [RelayCommand]
        public async Task GoToCarritoPage()
        {
          
           await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage(new ProductoListaViewModel(new ApiService())));
        }

        [RelayCommand]
        public async Task GoToPedidosPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PedidosPage()); 
        }
    }
}
