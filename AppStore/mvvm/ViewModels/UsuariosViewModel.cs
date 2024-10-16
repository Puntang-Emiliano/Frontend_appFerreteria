using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using AppStore.Models;
using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Views;

namespace AppStore.ViewModels
{
    public partial class UsuariosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
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
                Usuarios.Clear();
                foreach (var usuario in usuarios)
                {
                    Usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        [RelayCommand]
        public async Task GoToUsuariosAgregar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioAgregarPage(new UsuarioAgregarViewModel(new ApiService())));

        }
    }
}
