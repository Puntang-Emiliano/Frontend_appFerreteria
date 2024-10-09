using AppStore.mvvm.Models;
using AppStore.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using System.Net;

namespace AppStore.mvvm.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string nombre = string.Empty;

       
        public IRelayCommand HomeCommand { get; }
        public IRelayCommand UsuariosCommand { get; }
        public IRelayCommand CarritoCommand { get; }
        public IRelayCommand PedidosCommand { get; }

        public HomeViewModel()
        {
            Title = "Menu";

           
            HomeCommand = new RelayCommand(OnHomeCommandExecuted);
            UsuariosCommand = new RelayCommand(OnUsuariosCommandExecuted);
            CarritoCommand = new RelayCommand(OnCarritoCommandExecuted);
            PedidosCommand = new RelayCommand(OnPedidosCommandExecuted);
        }

        
        private async void OnHomeCommandExecuted()
        {
           
            await Shell.Current.GoToAsync("//HomePage");
        }

        private async void OnUsuariosCommandExecuted()
        {
            
            await Shell.Current.GoToAsync("//UsuariosPage");
        }

        private async void OnCarritoCommandExecuted()
        {
           
            await Shell.Current.GoToAsync("//CarritoPage");
        }

        private async void OnPedidosCommandExecuted()
        {
            
            await Shell.Current.GoToAsync("//PedidosPage");
        }
    }
}
