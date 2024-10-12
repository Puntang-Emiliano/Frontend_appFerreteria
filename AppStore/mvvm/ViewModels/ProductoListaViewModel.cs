using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using System.Threading.Tasks;
using AppStore.Models;
using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Views;

namespace AppStore.mvvm.ViewModels
{
    public class ProductoListaViewModel
    {
        private readonly ApiService _apiService; // Inyección del ApiService
        public ObservableCollection<Producto> Productos { get; } = new ObservableCollection<Producto>();

        public ICommand CargarProductosCommand { get; }

        public ProductoListaViewModel(ApiService apiService)
        {
            _apiService = apiService;
            CargarProductosCommand = new RelayCommand(async () => await OnCargarProductos());
        }

        private async Task OnCargarProductos()
        {
            try
            {
                var productos = await _apiService.GetProductos();
                Productos.Clear(); // Limpiar la colección existente
                foreach (var producto in productos)
                {
                    Productos.Add(producto); // Agregar nuevos productos a la colección
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes mostrar un mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
