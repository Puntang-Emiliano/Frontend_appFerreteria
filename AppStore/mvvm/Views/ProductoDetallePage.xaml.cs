using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Models;

namespace AppStore.mvvm.Views
{
    [QueryProperty(nameof(SelectedProducto), "SelectedProducto")]
    public partial class ProductoDetallePage : ContentPage
    {
        public ProductoDetallePage()
        {
            InitializeComponent();
        }

        
        public Producto SelectedProducto
        {
            set
            {
                var viewModel = BindingContext as ProductoDetalleViewModel;
                if (viewModel != null)
                {
                    viewModel.CargarProducto(value);
                }
            }
        }
    }
}
