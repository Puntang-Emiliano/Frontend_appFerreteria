using AppStore.mvvm.ViewModels;

namespace AppStore.mvvm.Views;

public partial class ProductoAgregarPage : ContentPage
{
    public ProductoAgregarPage(ProductoAgregarViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}