using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.WeatherForecast;
using ApiSolcaClase.Repository.MUsers;
using Microsoft.Extensions.Configuration;

namespace ApiSolcaClase.Bll.WeatherForecast
{
    public class WeatherForecastBll : IWeatherForecastBll
    {
        private readonly IUserRepository UserRep;
        private readonly IConfiguration _configuration;

        public WeatherForecastBll(IConfiguration configuration, IUserRepository UserRep)
        {
            _configuration = configuration;
            this.UserRep = UserRep;
        }


        public ResponseModelGeneral<string> DecryptPass(WheatherForecastRequestModel resqModel)
        {
            HelperGeneral HelG = new HelperGeneral();
            string? textT = HelG.DesencryptPassWord(resqModel.text);

            if(textT != null)
            {
                return new ResponseModelGeneral<string>(
                    200,
                    "Ok",
                    textT,
                    ""
                );
            } else
            {
                return new ResponseModelGeneral<string>(
                    500,
                    MessageHelper.ErrorGeneral,
                    textT,
                    MessageHelper.ErrorPasswordDesencrypt
                );
            }
        }

        //public List<Users> GetListUsers()
        //{
        //    return UserRep.GetListUsers();
        //}
    }
}
