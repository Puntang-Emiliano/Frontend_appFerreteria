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
        private string nombre = Transport.nombre;  // Aquí puedes asignar dinámicamente el nombre

        // Comandos para la navegación
        public IRelayCommand HomeCommand { get; }
        public IRelayCommand UsuariosCommand { get; }
        public IRelayCommand CarritoCommand { get; }
        public IRelayCommand PedidosCommand { get; }

        // Constructor
        public HomeViewModel()
        {
            Title = "Menú";  // Título de la página

            // Inicialización de los comandos
            HomeCommand = new RelayCommand(OnHomeCommandExecuted);
            UsuariosCommand = new RelayCommand(OnUsuariosCommandExecuted);
            CarritoCommand = new RelayCommand(OnCarritoCommandExecuted);
            PedidosCommand = new RelayCommand(OnPedidosCommandExecuted);
        }

        // Comando para la navegación a la página Home
        private async void OnHomeCommandExecuted()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }

        // Comando para la navegación a la página Usuarios
        private async void OnUsuariosCommandExecuted()
        {
            await Shell.Current.GoToAsync("//UsuariosPage");
        }

        // Comando para la navegación a la página Carrito
        private async void OnCarritoCommandExecuted()
        {
            await Shell.Current.GoToAsync("//CarritoPage");
        }

        // Comando para la navegación a la página Pedidos
        private async void OnPedidosCommandExecuted()
        {
            await Shell.Current.GoToAsync("//PedidosPage");
        }
    }
}
