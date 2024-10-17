using AppStore.mvvm.Models;
using System.Text.Json;
using System.Text;
using AppStore.Models;
using AppStore.mvvm.Models.DTO;
using CommunityToolkit.Mvvm.Input;


namespace AppStore
{
    public class ApiService
    {
        private static readonly string BASE_URL = "http://localhost:5154/api/";
        static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

       
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

        public static async Task<bool> AgregarUsuario(CrearUsuarioDTO _usuario)
        {
            string FINAL_URL = BASE_URL + "usuarios";
            try
            {
              

                var content = new StringContent(
                    JsonSerializer.Serialize(_usuario),
                    Encoding.UTF8, "application/json"

                );

                var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);

                if (result.IsSuccessStatusCode) 
                {
                   
                    return true;
                }

                
                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar usuario: {errorResponse}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

  
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

     
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

        public static async Task<bool> EliminarUsuario(int usuario_id)
        {
            string FINAL_URL = BASE_URL + $"usuarios/{usuario_id}";
            try
            {
                var result = await httpClient.DeleteAsync(FINAL_URL).ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar usuario: {errorResponse}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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


        public async Task EditarUsuario(Usuario usuario)
        {
            var json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"api/usuarios/{usuario.usuario_id}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al editar el usuario: " + response.ReasonPhrase);
            }
        }


    }
}
