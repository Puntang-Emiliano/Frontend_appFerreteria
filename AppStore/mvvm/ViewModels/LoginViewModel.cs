using AppStore.mvvm.Models;
using AppStore.mvvm.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using System.Net;

namespace AppStore.mvvm.ViewModels;

public partial class LoginViewModel : BaseViewModel
{


    [ObservableProperty] private string email = string.Empty;
    [ObservableProperty] private string contraseña = string.Empty;
    [ObservableProperty] private string message = string.Empty;

    [RelayCommand]
    public async Task LoginAsync2()
    {
        // await Application.Current.MainPage.DisplayAlert("Login", "Login", "Ok");

        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage(new ProductoListaViewModel()));
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        if (!IsBusy)
        {
            IsBusy = true;

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(contraseña))
            {
                var apiClient = new ApiService();

                try
                {
                    var login = await apiClient.ValidarLogin(email, contraseña);

                    // Si la llamada es exitosa y usuario_id es diferente de 0
                    Transport.usuario_id = login.usuario_id;
                    Transport.nombre = login.nombre;
                    Transport.email = login.email;

                    await Application.Current.MainPage.DisplayAlert("Atención", "Éxito", "Aceptar");

                    // Navega a la siguiente página (después de un inicio de sesión exitoso)
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage(new ProductoListaViewModel()));
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Atención", ex.Message, "Aceptar");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Atención", "Las credenciales son obligatorias. Verifique!", "Aceptar");
            }

            IsBusy = false;
        }
    }


}
