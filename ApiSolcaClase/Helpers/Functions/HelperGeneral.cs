using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models;

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
    }
}
