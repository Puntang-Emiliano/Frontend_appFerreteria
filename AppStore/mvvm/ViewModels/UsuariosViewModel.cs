using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using AppStore.Models;

namespace AppStore.ViewModels
{
    public class UsuariosViewModel
    {
        private readonly ApiService _apiService; // Inyección del ApiService
        public ObservableCollection<Usuario> Usuarios { get; } = new ObservableCollection<Usuario>();

        public ICommand CargarUsuariosCommand { get; }

        public UsuariosViewModel(ApiService apiService)
        {
            _apiService = apiService;
            CargarUsuariosCommand = new RelayCommand(async () => await OnCargarUsuarios());
        }

        private async Task OnCargarUsuarios()
        {
            try
            {
                var usuarios = await _apiService.GetUsuarios();
                Usuarios.Clear(); // Limpiar la colección existente
                foreach (var usuario in usuarios)
                {
                    Usuarios.Add(usuario); // Agregar nuevos usuarios a la colección
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes mostrar un mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
