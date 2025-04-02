using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Models.DB;

namespace ApiSolcaClase.Helpers.Models
{
    public class ResponseModelGeneral<T>
    {
        public ResponseModelGeneral(int code, string message, T data, string messageDev = "", ModelContext? db = null, bool ExecuteRollback = false)
        {
            ConfigData(db, ExecuteRollback, messageDev: messageDev);

            this.code = code;
            this.message = message;
            this.data = data;

            SaveLog();
        }

        public ResponseModelGeneral(int code, string message, string messageDev = "", ModelContext? db = null, bool ExecuteRollback = false)
        {
            ConfigData(db, messageDev: messageDev);

            this.code = code;
            this.message = message;
            this.data = data;

            SaveLog();
        }

        public int code { get; set; }
        public T? data { get; set; }
        public string message { get; set; }
        public string messageDev { get; set; }

        private void ConfigData(ModelContext? db = null, bool ExecuteRollback = false, string messageDev = null)
        {
            IConfiguration configuration = HelperGeneral.GetEnvVar();
            bool isDebug = configuration.GetValue<bool>("isDebug");

            if (ExecuteRollback)
            {
                db.Database.RollbackTransaction();
            }

            this.messageDev = isDebug ? messageDev : "";
        }


        private void SaveLog()
        {
            if (
                (messageDev ?? "") == "" &&
                message == "" &&
                (data == null || (data == null ? "" : data.ToString()) == "")
            ) return;

            MongoHelper MongoH = new MongoHelper();
            MongoModels.LogProcesMongoModel LogProcM = new MongoModels.LogProcesMongoModel();
            LogProcM.Process = "ResponseModelGeneral";
            LogProcM.Message = (messageDev ?? "") != ""
                ? $"{message} - {messageDev}"
                : message;
            MongoH.InsertLogProc(LogProcM);
        }
    }
}
