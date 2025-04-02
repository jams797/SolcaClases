using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.Security;
using ApiSolcaClase.Models.AppModels.WeatherForecast;

namespace ApiSolcaClase.Validator.WeatherForecast
{
    public class WeatherForecastValidate
    {

        public WeatherForecastValidate()
        {
        }

        public ResponseModelGeneral<LoginResponseModel> ValidatePost(WheatherForecastRequestModel ReqModel)
        {
            ValidateHelper<LoginResponseModel> ValidH = new ValidateHelper<LoginResponseModel>();

            ResponseModelGeneral<LoginResponseModel> ValText = ValidH.ValidResp(ReqModel.text, "text", 50, 2);
            if (ValText.code != 200) return ValText;

            return new ResponseModelGeneral<LoginResponseModel>(200, "");
        }
    }
}
