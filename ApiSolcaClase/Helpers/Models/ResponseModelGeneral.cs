using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Helpers.Models
{
    public class ResponseModelGeneral
    {
        public ResponseModelGeneral(int code, string message, dynamic data = null, string messageDev = "", ModelContext? db = null, bool ExecuteRollback = false)
        {
            IConfiguration configuration = HelperGeneral.GetEnvVar();
            bool isDebug = configuration.GetValue<bool>("isDebug");

            if(ExecuteRollback)
            {
                db.Database.RollbackTransaction();
            }

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
