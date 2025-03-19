using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.WeatherForecast;
using Microsoft.Extensions.Configuration;

namespace ApiSolcaClase.Bll.WeatherForecast
{
    public class WeatherForecastBll
    {
        private readonly IConfiguration _configuration;

        public WeatherForecastBll(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public ResponseModelGeneral DecryptPass(WheatherForecastRequestModel resqModel)
        {
            HelperGeneral HelG = new HelperGeneral();
            string? textT = HelG.DesencryptPassWord(resqModel.text);

            if(textT != null)
            {
                return new ResponseModelGeneral(
                    200,
                    "Ok",
                    textT,
                    ""
                );
            } else
            {
                return new ResponseModelGeneral(
                    500,
                    "Ocurrio un error al descifrar el dato",
                    textT,
                    "Error en el catch de desencriptar la clave"
                );
            }
        }
    }
}
