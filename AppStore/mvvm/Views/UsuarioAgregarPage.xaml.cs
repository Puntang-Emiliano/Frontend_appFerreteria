using AppStore.mvvm.ViewModels;
using Microsoft.Maui.Controls;

namespace AppStore.mvvm.Views
{
    public partial class UsuarioAgregarPage : ContentPage
    {
        public UsuarioAgregarPage(UsuarioAgregarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; 
        }
    }
}
