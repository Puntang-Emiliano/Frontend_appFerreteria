using AppStore.Models;
using AppStore.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace AppStore.mvvm.ViewModels
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Usuario usuario;

        [ObservableProperty]
        Usuario usuarioSeleccionado;

        private readonly ApiService _apiService; // Servicio para manejar usuarios
      
        public UsuarioDetalleViewModel(Usuario usuarioSeleccionado, ApiService _apiService)
        {
            Title = "Detalle de usuario";
            usuario = usuarioSeleccionado;
            this._apiService = _apiService; // Inicializa el servicio
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task EditarUsuarioAsync()
        {
            // Confirmación de edición
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Confirmar",
                                "¿Seguro que deseas editar este usuario?", "Sí", "No");

            if (confirmacion)
            {
                try
                {
                    // Llama al servicio API para editar el usuario
                    await _apiService.EditarUsuario(Usuario);

                    // Muestra un mensaje de éxito
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El usuario fue editado correctamente", "OK");

                    // Vuelve a la página anterior
                    await GoBack();
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de error en caso de fallo
                    await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo editar el usuario: {ex.Message}", "OK");
                }
            }
        }

        [RelayCommand]
        private async Task EliminarUsuarioAsync()
        {
            // Confirmar eliminación
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Confirmar",
                                "¿Seguro que deseas eliminar este usuario?", "Sí", "No");
            if (confirmacion)
            {
                // Lógica para eliminar el usuario
                bool resultado = await ApiService.EliminarUsuario(Usuario.usuario_id); // Asegúrate de que Usuario tenga una propiedad Id
                if (resultado)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El usuario fue eliminado correctamente", "OK");
                    await GoBack(); // Vuelve a la página anterior después de eliminar
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el usuario", "OK");
                }
            }
        }

        public void CargarUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
