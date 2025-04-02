using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.WeatherForecast;


namespace ApiSolcaClase.Bll.WeatherForecast
{
    public interface IWeatherForecastBll
    {
        public ResponseModelGeneral<string> DecryptPass(WheatherForecastRequestModel resqModel);
        //public List<Users> GetListUsers();
    }
}
