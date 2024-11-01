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

        public static async Task<Usuario> GetUsuarioPorId(int id)
        {
            string FINAL_URL = BASE_URL + "usuarios/" + id;

            try
            {
                var response = await httpClient.GetAsync(FINAL_URL);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        var responseObject = JsonSerializer.Deserialize<Usuario>(jsonData,
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
            string FINAL_URL = BASE_URL + $"usuarios/{usuario.usuario_id}";

            var json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(FINAL_URL, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception("Error al editar el usuario: " + errorResponse);
            }
        }


        public static async Task<bool> AgregarProducto(Producto producto)
        {
           string FINAL_URL = BASE_URL + "productos";
           

            try
            {
                var content = new StringContent(
                    JsonSerializer.Serialize(producto),
                    Encoding.UTF8, "application/json"
                );

                var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar producto: {result.StatusCode}, Detalles: {errorResponse}");
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Error de conexión al intentar agregar producto: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en AgregarProducto: {ex.Message}");
            }
        }




        public async Task EditarProducto(Producto producto)
        {
            string FINAL_URL = BASE_URL + $"productos/{producto.producto_id}";

            try
            {
                var json = JsonSerializer.Serialize(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(FINAL_URL, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al editar el producto: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al intentar editar el producto: {ex.Message}");
            }
        }


        //metodo para taer id Categorias
        public async Task<List<Categoria>> ObtenerCategorias()
        {
            string url = BASE_URL + "categorias";

            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var categorias = JsonSerializer.Deserialize<List<Categoria>>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                if (categorias == null)
                {
                    throw new Exception("No se pudo obtener la lista de categorías.");
                }

                return categorias;
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Error de conexión al obtener categorías: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                throw new Exception($"Error en el formato de datos al obtener categorías: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener categorías: {ex.Message}");
            }
        }

        //Eliminar producto
 public static async Task<bool> EliminarProducto(int producto_id)
 {
     string FINAL_URL = BASE_URL + $"productos/{producto_id}";
     try
     {
         var result = await httpClient.DeleteAsync(FINAL_URL).ConfigureAwait(false);

         if (result.IsSuccessStatusCode)
         {
             return true;
         }

         var errorResponse = await result.Content.ReadAsStringAsync();
         throw new Exception($"Error al eliminar producto: {errorResponse}");
     }
     catch (Exception ex)
     {
         throw new Exception(ex.Message);
     }
 }


    }
}
