namespace ApiSolcaClase.Models.AppModels.WeatherForecast
{
    public class WeatherForecastModelReponse
    {
        public WeatherForecastModelReponse(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public int code { get; set; }
        public string message { get; set; }
    }
}
