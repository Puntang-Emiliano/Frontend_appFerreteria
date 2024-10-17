using AppStore.mvvm.ViewModels;
using Microsoft.Maui.Controls;

namespace AppStore.mvvm.Views
{
    public partial class UsuarioEditarPage : ContentPage
    {
        public UsuarioEditarPage(UsuarioEditarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
