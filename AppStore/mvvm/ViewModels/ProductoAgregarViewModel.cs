using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppStore.mvvm.Models;
using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using AppStore.mvvm.Models.DTO;

namespace AppStore.mvvm.ViewModels
{
    public partial class ProductoAgregarViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<CrearProductoDTO> ProductosCrear { get; set; } = new ObservableCollection<CrearProductoDTO>();
        public ObservableCollection<Producto> Productos { get; set; } = new ObservableCollection<Producto>();

        [ObservableProperty] private string nombre;
        [ObservableProperty] private string descripcion;
        [ObservableProperty] private decimal precio;
        [ObservableProperty] private int stock;
        [ObservableProperty] private int categoriaId;
        [ObservableProperty] private string marca;
        [ObservableProperty] private string imagen; // Nueva propiedad para la imagen

        public ProductoAgregarViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Title = Constants.AppName;
        }

        [RelayCommand]
        private async Task CancelarProducto()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task GrabarProducto()
        {
            var _producto = new CrearProductoDTO
            {
                Nombre = this.nombre,
                Descripcion = this.descripcion,
                Precio = this.precio,
                Stock = this.stock,
                CategoriaId = this.categoriaId,
                Marca = this.marca,
                Imagen = this.imagen // Añadir la imagen aquí
            };

            try
            {
                await ApiService.AgregarProducto(_producto);
                await Application.Current.MainPage.DisplayAlert("Éxito", "Nuevo producto agregado.", "Aceptar");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
