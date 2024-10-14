using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;

namespace AppStore.mvvm.ViewModels
{
    public partial class UsuarioAgregarViewModel : BaseViewModel
    {
        private readonly ApiService _apiService; // Inyección del ApiService
        public ObservableCollection<Usuario> Usuarios { get; } = new ObservableCollection<Usuario>();

        [ObservableProperty] private string nombre;
        [ObservableProperty] private string email;
        [ObservableProperty] private string direccion;
        [ObservableProperty] private string rol;
        [ObservableProperty] private string contraseña;

        public UsuarioAgregarViewModel(ApiService apiService)
        {
            _apiService = apiService; // Asigna el ApiService recibido por el constructor
            Title = Constants.AppName;
        }

        [RelayCommand]
        private async Task CancelarUsuario()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task GrabarUsuario()
        {
            var nuevoUsuario = new Usuario
            {
                nombre = this.nombre,
                email = this.email,
                direccion = this.direccion,
                rol = this.rol,
                contraseña = this.contraseña
            };

            try
            {
                await ApiService.AgregarUsuario(nuevoUsuario);

                await Application.Current.MainPage.DisplayAlert("Exito", "Se nuevo Producto.", "Aceptar");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
            }

            await Application.Current.MainPage.Navigation.PopAsync();


        }
    }
}