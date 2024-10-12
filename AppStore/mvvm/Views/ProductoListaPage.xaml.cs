using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views
{
    public partial class ProductoListaPage : ContentPage
    {
        public ProductoListaPage(ProductoListaViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
