using ApiSolcaClase.Helpers.Functions;

namespace ApiSolcaClase.Helpers.Models
{
    public class ResponseModelGeneral
    {
        public ResponseModelGeneral(int code, string message, dynamic data = null, string messageDev = "")
        {
            IConfiguration configuration = HelperGeneral.GetEnvVar();
            bool isDebug = configuration.GetValue<bool>("isDebug");

            this.code = code;
            this.message = message;
            this.data = data;
            this.messageDev = isDebug ? messageDev : "";
        }

        public int code { get; set; }
        public dynamic data { get; set; }
        public string message { get; set; }
        public string messageDev { get; set; }
    }
}
