using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppStore.mvvm.ViewModels
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {

        [ObservableProperty]
        private Usuario usuario;

 

        public UsuarioDetalleViewModel(Usuario usuarioSeleccionado)
        {
            Title = "Detalle de usuario";
            usuario = usuarioSeleccionado;
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void CargarUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
