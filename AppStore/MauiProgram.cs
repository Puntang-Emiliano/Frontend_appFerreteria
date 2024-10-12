using AppStore.mvvm.ViewModels;
using AppStore.mvvm.Views;
using AppStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace AppStore
{
    public static class MauiProgram
    {
        private const string BaseAddress = "http://localhost:5154/";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registro de servicios
            builder.Services.AddSingleton<ApiService>(); // Registra ApiService como singleton
            builder.Services.AddTransient<UsuariosViewModel>(); // Registra UsuariosViewModel como transient
            builder.Services.AddTransient<ProductoListaViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
