using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.WeatherForecast;

namespace ApiSolcaClase.Validator.WeatherForecast
{
    public class WeatherForecastValidate
    {
        ValidateHelper ValidH;

        public WeatherForecastValidate()
        {
            ValidH = new ValidateHelper();
        }

        public ResponseModelGeneral ValidatePost(WheatherForecastRequestModel ReqModel)
        {

            ResponseModelGeneral ValText = ValidH.ValidResp(ReqModel.text, "text", 50, 2);
            if (ValText.code != 200) return ValText;

            return new ResponseModelGeneral(200, "");
        }
    }
}
