using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using System.Threading.Tasks;
using AppStore.Models;
using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppStore.mvvm.ViewModels
{
    public partial class ProductoListaViewModel : ObservableObject
    {
        private readonly ApiService _apiService; 
        public ObservableCollection<Producto> Productos { get; } = new ObservableCollection<Producto>();

        [ObservableProperty]
        Producto productoSeleccionado;

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
                Productos.Clear(); 
                foreach (var producto in productos)
                {
                    Productos.Add(producto); 
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

      
        partial void OnProductoSeleccionadoChanged(Producto value)
        {
            _ = GoToDetail(value); 
        }

        private async Task GoToDetail(Producto producto)
        {
            if (producto != null)
            {
               
                await Application.Current.MainPage.Navigation.PushAsync(new DetalleProductoPage(producto)); // Crea la página con el producto seleccionado
            }
        }
    }
}
