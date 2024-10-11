using AppStore.ViewModels;
using Microsoft.Maui.Controls;

namespace AppStore.mvvm.Views
{
    public partial class UsuariosPage : ContentPage
    {
        public UsuariosPage(UsuariosViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; // Establecer el contexto de enlace
        }
    }
}
