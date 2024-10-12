using AppStore.mvvm.Models;
using System.Net.Http;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppStore.Models;

namespace AppStore
{
    public class ApiService
    {
        private static readonly string BASE_URL = "http://localhost:5154/api/";
        static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

        // Método para obtener la lista de productos
        //public async Task<List<Producto>> GetProductos()
        //{
        //    string FINAL_URL = BASE_URL + "productos";

        //    try
        //    {
        //        var response = await httpClient.GetAsync(FINAL_URL);
        //        if (response.IsSuccessStatusCode) // Verificación simplificada del estado de respuesta
        //        {
        //            var jsonData = await response.Content.ReadAsStringAsync();
        //            if (!string.IsNullOrWhiteSpace(jsonData))
        //            {
        //                var responseObject = JsonSerializer.Deserialize<List<Producto>>(jsonData,
        //                    new JsonSerializerOptions
        //                    {
        //                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //                        WriteIndented = true
        //                    });
        //                return responseObject!;
        //            }
        //            else
        //            {
        //                throw new Exception("Resource Not Found"); // Excepción si no hay datos
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Request failed with status code " + response.StatusCode); // Manejo de errores
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error fetching products: {ex.Message}"); // Mensaje de error más claro
        //    }
        //}

        // Método para validar el login
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
                        throw new Exception("Credenciales incorrectas");
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
            catch (Exception ex)
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

  
    // Método para obtener la lista de usuarios
        public async Task<List<Usuario>> GetUsuarios()
        {
            string FINAL_URL = BASE_URL + "usuarios";

            try
            {
                var response = await httpClient.GetAsync(FINAL_URL);
                if (response.IsSuccessStatusCode)
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
                throw new Exception(ex.Message);
            }
        }

        // Método para agregar un nuevo producto
        public async Task<List<Producto>> GetProductos()
        {
            string FINAL_URL = BASE_URL + "productos";

            try
            {
                var response = await httpClient.GetAsync(FINAL_URL);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        var responseObject = JsonSerializer.Deserialize<List<Producto>>(jsonData,
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

        // Método para obtener un producto por su ID
        public static async Task<Producto> GetProductoPorId(int id)
        {
            string FINAL_URL = BASE_URL + "productos/" + id;

            try
            {
                var response = await httpClient.GetAsync(FINAL_URL);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        var responseObject = JsonSerializer.Deserialize<Producto>(jsonData,
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
    }
}

