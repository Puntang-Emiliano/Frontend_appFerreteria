using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.Models;

using AppStore.mvvm.Views;
using AppStore.mvvm.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppStore.ViewModels
{
    public partial class UsuariosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Usuario> Usuarios { get; } = new ObservableCollection<Usuario>();

        [ObservableProperty]
        Usuario usuarioSeleccionado;

        public ICommand CargarUsuariosCommand { get; }
        public ICommand EditarUsuariosCommand { get; }

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

        public async Task EditarUsuario()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioEditarPage(new UsuarioEditarViewModel(new ApiService())));
        }

        partial void OnUsuarioSeleccionadoChanged(Usuario value)
        {
            _ = GoToDetail(value);
        }

        private async Task GoToDetail(Usuario usuario)
        {
            if (usuario != null)
            {
                var usuarioDetalleViewModel = new UsuarioDetalleViewModel(usuario);
                var detallePage = new UsuarioDetallePage { BindingContext = usuarioDetalleViewModel };

                await Application.Current.MainPage.Navigation.PushAsync(detallePage);
            }
        }

    }
}
