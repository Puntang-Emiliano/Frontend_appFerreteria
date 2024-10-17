using AppStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.mvvm.ViewModels
{
    public partial class UsuarioEditarViewModel : BaseViewModel
    {
        public UsuarioEditarViewModel(ApiService apiService)
        {
            Title = Constants.AppName;
        }

        

        [RelayCommand]
        private async Task Cancelar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task Grabar()
        {
            await Application.Current.MainPage.DisplayAlert("Producto", "Producto modificado", "Aceptar");
        }
    }
}
