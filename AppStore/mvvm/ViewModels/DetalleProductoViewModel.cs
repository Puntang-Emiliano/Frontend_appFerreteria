using AppStore.mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using AppStore.Models;

namespace AppStore.mvvm.ViewModels
{
    public partial class DetalleProductoViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Producto producto;

        [ObservableProperty]
        private int cantidad = 0;

        // Nueva propiedad para el detalle
        [ObservableProperty]
        private string detalle;

        public DetalleProductoViewModel(Producto productoSeleccionado)
        {
            Title = "Detalle de Producto";
            producto = productoSeleccionado;
            detalle = producto.descripcion; // O puedes establecer el detalle aquí
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private void AumentarCantidad()
        {
            cantidad++;
        }

        [RelayCommand]
        private void DisminuirCantidad()
        {
            if (cantidad > 0)
            {
                cantidad--;
            }
        }

        [RelayCommand]
        private async Task AgregarAlCarrito()
        {
            await Task.Delay(500);
            await Application.Current.MainPage.DisplayAlert("Éxito", $"Se ha agregado {cantidad} de {Producto.nombre} al carrito.", "OK");
        }
    }
}
