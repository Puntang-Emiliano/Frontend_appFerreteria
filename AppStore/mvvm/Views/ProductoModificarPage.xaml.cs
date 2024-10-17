using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class UsuarioEditarPage : ContentPage
{
	private ProductoModificarViewModel viewModel;
    public UsuarioEditarPage()
	{
		InitializeComponent();
		BindingContext = viewModel = new ProductoModificarViewModel();
    }
}