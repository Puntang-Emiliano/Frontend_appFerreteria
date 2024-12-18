using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Models;
using AppStore.Models;

namespace AppStore.mvvm.Views
{
    public partial class DetalleProductoPage : ContentPage
    {
       
        public DetalleProductoPage(Producto productoSeleccionado)
        {
            InitializeComponent(); 
            BindingContext = new DetalleProductoViewModel(productoSeleccionado);
          
        }
    }
}
