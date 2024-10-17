using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Models;
using AppStore.Models;

namespace AppStore.mvvm.Views
{
    [QueryProperty(nameof(SelectUsuario), "selectedUsuario")]
    public partial class UsuarioDetallePage : ContentPage
    {
        public UsuarioDetallePage()
        {
            InitializeComponent();
        }


        public Usuario SelectUsuario
        {
            set
            {
                var viewModel = BindingContext as UsuarioDetalleViewModel;
                if (viewModel != null)
                {
                    viewModel.CargarUsuario(value);
                }
            }
        }
    }
}