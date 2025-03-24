﻿using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.WeatherForecast;
using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Bll.WeatherForecast
{
    public interface IWeatherForecastBll
    {
        public ResponseModelGeneral DecryptPass(WheatherForecastRequestModel resqModel);
        public List<Users> GetListUsers();
    }
}
