using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace ApiSolcaClase.Helpers.Functions
{
    public class HttpHelper
    {
        public async Task SendHttp(string Url, string TypeRequest, string JsonString = null)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage? response;

                    switch (TypeRequest)
                    {
                        case "GET":
                            response = await client.GetAsync(Url);
                            break;
                        case "POST":
                            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                            response = await client.PostAsync(Url, content);
                            break;
                        default:
                            throw new Exception("Metodo no configurado");
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor: " + content);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                }
            }
        }
    }
}
