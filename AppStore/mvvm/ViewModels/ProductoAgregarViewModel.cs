using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models.DTO;
using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using AppStore.mvvm.Models;

namespace AppStore.mvvm.ViewModels
{
    public partial class ProductoAgregarViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Categoria> Categorias { get; set; } = new ObservableCollection<Categoria>();

        [ObservableProperty] private string nombre;
        [ObservableProperty] private string descripcion;
        [ObservableProperty] private decimal precio;
        [ObservableProperty] private int stock;
        [ObservableProperty] private int categoriaId;
        [ObservableProperty] private string marca;
        [ObservableProperty] private string imagen;

        public ProductoAgregarViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Title = "Agregar Producto";
            CargarCategorias();
        }

        public async Task CargarCategorias()
        {
            try
            {
                var categorias = await _apiService.ObtenerCategorias();
                Categorias.Clear();
                foreach (var categoria in categorias)
                {
                    Categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al cargar categorías: {ex.Message}", "Aceptar");
            }
        }

        [RelayCommand]
        private async Task CancelarProducto()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task GrabarProducto()
        {
            var nuevoProducto = new Producto
            {
                nombre = this.nombre,
                descripcion = this.descripcion,
                precio = this.precio,
                stock = this.stock,
                categoria_id = this.categoriaId,
                marca = this.marca,
                imagen = this.imagen
            };

            try
            {
                await ApiService.AgregarProducto(nuevoProducto);
                await Application.Current.MainPage.DisplayAlert("Éxito", "Producto agregado correctamente.", "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error al agregar producto: {ex.Message}", "Aceptar");
            }
        }
    }
}
