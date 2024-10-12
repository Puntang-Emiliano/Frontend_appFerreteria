using AppStore.mvvm.Models;
using System.Net.Http;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text;
using System.Net;
using AppStore.Models;


namespace AppStore;

public class ApiService
{
    private static readonly string BASE_URL = "http://localhost:5154/api/";
    static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };


    //public static async Task<List<Producto>> GetProductos()
    //{       
    //    string FINAL_URL = BASE_URL + "productos";

    //    try
    //    {
    //        var response = await httpClient.GetAsync(FINAL_URL);
    //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            var jsonData = await response.Content.ReadAsStringAsync();
    //            if (!string.IsNullOrWhiteSpace(jsonData))
    //            {
    //                // Inside the ApiService class
    //                var responseObject = JsonSerializer.Deserialize<List<Producto>>(jsonData, 
    //                    new JsonSerializerOptions {
    //                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    //                        WriteIndented = true
    //                    });
    //                return responseObject!;
    //            }
    //            else
    //            {
    //                Exception exception = new Exception("Resource Not Found");
    //                throw new Exception(exception.Message);
    //            }
    //        }
    //        else
    //        {
    //            Exception exception = new Exception("Request failed with status code " + response.StatusCode);
    //            throw new Exception(exception.Message);
    //        }
    //    }
    //    catch (Exception exception)
    //    {
    //        throw new Exception(exception.Message);
    //    }

    //
    //}

    public async Task<LoginResponseDto> ValidarLogin(string _email, string _contraseña)
    {
        string FINAL_URL = BASE_URL + "Usuarios/ValidarCredencial";
        try
        {
            var content = new StringContent(
                JsonSerializer.Serialize(new
                {
                    Email = _email,
                    Contraseña = _contraseña,
                }),
                Encoding.UTF8, "application/json"
            );

            var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);
            var jsonData = await result.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                var responseObject = JsonSerializer.Deserialize<LoginResponseDto>(jsonData,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });

                // Verifica si el usuario_id es 0
                if (responseObject.usuario_id == 0)
                {
                    throw new Exception("Credenciales incorrectas"); // Puedes lanzar una excepción personalizada
                }

                return responseObject;
            }
            else
            {
                throw new Exception("Resource Not Found");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Usuario>> GetUsuarios()
    {
        string FINAL_URL = BASE_URL + "usuarios"; // Asegúrate de que este endpoint esté configurado en tu API

        try
        {
            var response = await httpClient.GetAsync(FINAL_URL);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var responseObject = JsonSerializer.Deserialize<List<Usuario>>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });
                    return responseObject!;
                }
                else
                {
                    throw new Exception("Resource Not Found");
                }
            }
            else
            {
                throw new Exception("Request failed with status code " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }




    public static async Task<bool> AgregarUsuario(Usuario _usuario)
    {
        string FINAL_URL = BASE_URL + "usuarios";
        try
        {
            var content = new StringContent(
                JsonSerializer.Serialize(_usuario),
                Encoding.UTF8, "application/json"
            );

            var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);

            if (result.IsSuccessStatusCode) // Cambié aquí
            {
                // Aquí puedes agregar lógica para obtener el ID o detalles del usuario creado
                return true;
            }
            else
            {
                // Puedes leer el mensaje de error de la respuesta para diagnosticar
                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar usuario: {errorResponse}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}