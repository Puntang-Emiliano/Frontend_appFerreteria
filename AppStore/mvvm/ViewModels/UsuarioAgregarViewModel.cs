using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using AppStore.mvvm.Models.DTO;

namespace AppStore.mvvm.ViewModels
{
    public partial class UsuarioAgregarViewModel : BaseViewModel
    {
        private readonly ApiService _apiService; 
        public ObservableCollection<CrearUsuarioDTO> Usuarioscrear { get; set; } = new ObservableCollection<CrearUsuarioDTO>();
        public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();

        [ObservableProperty] private string nombre;
        [ObservableProperty] private string email;
        [ObservableProperty] private string direccion;
        [ObservableProperty] private string rol;
        [ObservableProperty] private string contraseña;

        public UsuarioAgregarViewModel(ApiService apiService)
        {
            _apiService = apiService; 
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
            var _usuario = new CrearUsuarioDTO
            {
                nombre = this.nombre,
                email = this.email,
                direccion = this.direccion,
                rol = this.rol,
                contraseña = this.contraseña
            };

            try
            {
                await ApiService.AgregarUsuario(_usuario);

                await Application.Current.MainPage.DisplayAlert("Exito", "Se un nuevo Producto.", "Aceptar");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
            }

            await Application.Current.MainPage.Navigation.PopAsync();


        }
    }
}