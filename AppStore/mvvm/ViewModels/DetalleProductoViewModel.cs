using AppStore.mvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace AppStore.mvvm.ViewModels
{
    public partial class DetalleProductoViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Producto producto;

        [ObservableProperty]
        private int cantidad = 0;

        public DetalleProductoViewModel(Producto productoSeleccionado)
        {
            Title = "Detalle de Producto";
            producto = productoSeleccionado;
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
            // Disminuir la cantidad en 1 si es mayor a 0
            if (cantidad > 0)
            {
                cantidad--;
            }
        }

        [RelayCommand]
        private async Task AgregarAlCarrito()
        {
            // Aquí deberías implementar la lógica para agregar el producto al carrito
            // Simulación de agregar al carrito
            await Task.Delay(500); // Simula el tiempo que tomaría agregar al carrito
            await Application.Current.MainPage.DisplayAlert("Éxito", $"Se ha agregado {cantidad} de {Producto.nombre} al carrito.", "OK");
        }
    }
}
