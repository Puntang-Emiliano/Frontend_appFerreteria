﻿using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using AppStore.mvvm.Views;





namespace AppStore.mvvm.ViewModels
{
    public partial class ProductoDetalleViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Producto producto;

        [ObservableProperty]
        Producto productoSeleccionado;

        private readonly ApiService _apiService; // Servicio para manejar productos

        public ProductoDetalleViewModel(Producto productoSeleccionado, ApiService apiService)
        {
            Title = "Detalle de producto";
            producto = productoSeleccionado;
            this._apiService = apiService; // Inicializa el servicio
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task EditarProductoAsync()
        {
            
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Confirmar",
                                "¿Seguro que deseas editar este producto?", "Sí", "No");

            if (confirmacion)
            {
                try
                {
                  
                    await _apiService.EditarProducto(Producto);

                   
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El producto fue editado correctamente", "OK");

                   
                    await GoBack();
                }
                catch (Exception ex)
                {
                    
                    await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo editar el producto: {ex.Message}", "OK");
                }
            }
        }

        [RelayCommand]
        private async Task EliminarProductoAsync()
        {
            
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Confirmar",
                                "¿Seguro que deseas eliminar este producto?", "Sí", "No");
            if (confirmacion)
            {
               
                bool resultado = await ApiService.EliminarProducto(Producto.producto_id); 
                if (resultado)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "El producto fue eliminado correctamente", "OK");
                    await GoBack(); 
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el producto", "OK");
                }
            }
        }

        public void CargarProducto(Producto producto)
        {
            Producto = producto;
        }
    }
}
