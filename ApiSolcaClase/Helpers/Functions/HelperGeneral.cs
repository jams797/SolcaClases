using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;
using System.Text.RegularExpressions;

namespace ApiSolcaClase.Helpers.Functions
{
    public class HelperGeneral
    {

        public DataEncryptModel GetDataEncrypt(string method)
        {
            IConfiguration configuration = HelperGeneral.GetEnvVar().GetSection("dataEncrypt").GetSection(method);
            return new DataEncryptModel(configuration.GetValue<string>("key"), configuration.GetValue<string>("iv"));
        }

        public string? EncryptPassWord(string text)
        {
            DataEncryptModel dataM = GetDataEncrypt(VarHelper.VarEncryptPassword);
            string? textT = AES256Encryption.Encrypt(text, dataM.key, dataM.iv);
            return textT;
        }

        public string? DesencryptPassWord(string text)
        {
            DataEncryptModel dataM = GetDataEncrypt(VarHelper.VarEncryptPassword);
            string? textT = AES256Encryption.Decrypt(text, dataM.key, dataM.iv);
            return textT;
        }

        public static IConfiguration GetEnvVar()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return configuration;
        }

        public bool PasswordIsStrong(string passwordV)
        {
            //letras de la A a la Z, mayusculas y minusculas
            Regex letras = new Regex(@"[a-zA-z]");
            //digitos del 0 al 9
            Regex numeros = new Regex(@"[0-9]");
            //cualquier caracter del conjunto
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            Boolean cumpleCriterios = false;

            //si no contiene las letras, regresa false
            if (!letras.IsMatch(passwordV))
            {
                return false;
            }
            //si no contiene los numeros, regresa false
            if (!numeros.IsMatch(passwordV))
            {
                return false;
            }

            //si no contiene los caracteres especiales, regresa false
            if (!caracEsp.IsMatch(passwordV))
            {
                return false;
            }

            //si cumple con todo, regresa true
            return true;
        }

        public string GenerateJwt(SessionModel SessionM)
        {
            IConfiguration Configuration = HelperGeneral.GetEnvVar().GetSection("jwt");
            JwtGenerator JWTG = new JwtGenerator(
                SecretKey: Configuration.GetValue<string>("secretKey"),
                Name: Configuration.GetValue<string>("name"),
                Rol: Configuration.GetValue<string>("rol"),
                Issuer: Configuration.GetValue<string>("issuer"),
                Audience: Configuration.GetValue<string>("audience"),
                DurationSec: Configuration.GetValue<int>("durationSec")
            );

            return JWTG.GenerateJwt();
        }
    }
}
