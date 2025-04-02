using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Helpers.Models.MongoModels;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace ApiSolcaClase.Helpers.Functions
{
    public class HttpHelper<T>
    {
        MongoHelper MongoH;

        public HttpHelper()
        {
            this.MongoH = new MongoHelper();
        }

        public async Task<ResponseModelGeneral<T>> SendHttp(string Url, string TypeRequest, string JsonString = null)
        {
            using (var client = new HttpClient())
            {
                try
                {

                    HttpResponseMessage? response;

                    SaveLog("Request", "", JsonString);

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

                        SaveLog("Response - OK", "", content);

                        return new ResponseModelGeneral<T>(200, content);
                    }
                    else
                    {
                        SaveLog("Response - Error", "", response.StatusCode);
                        Console.WriteLine($"Error: {response.StatusCode}");
                        return new ResponseModelGeneral<T>(500, MessageHelper.ErrorGeneral, "");
                    }
                }
                catch (Exception ex)
                {
                    SaveLog("Response - Catch", "", ex.Message);
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                    return new ResponseModelGeneral<T>(500, MessageHelper.ErrorGeneral, messageDev: ex.Message);
                }
            }
        }

        public void SaveLog(string Process, string Message, object Data)
        {
            LogProcesMongoModel ProcM = new LogProcesMongoModel();
            ProcM.Process = $"SendHttp - {Process}";
            ProcM.Message = Message;
            ProcM.DataReq = Data;
            MongoH.InsertLogProc(ProcM);
        }
    }
}
