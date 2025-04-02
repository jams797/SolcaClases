using ApiSolcaClase.Helpers.Data;
using ApiSolcaClase.Helpers.Models.MongoModels;
using MongoDB.Driver;
using MongoLibrary;

namespace ApiSolcaClase.Helpers.Functions
{
    public class MongoHelper
    {

        private IMongoDatabase GetDb(string Conection, string Db)
        {
            return new MongoLibrary.MongoConection(HelperGeneral.GetEnvVar().GetValue<string>(Conection) ?? "", Db).dbMongo;
        }

        public async Task InsertLogProc(LogProcesMongoModel model, StreamReader? StreamBody = null)
        {
            IMongoDatabase dbMongo = GetDb("MongoDb", MongoDbDataHelper.DbLogs);

            IMongoCollection<LogProcesMongoModel> collection = dbMongo.GetCollection<LogProcesMongoModel>(MongoDbDataHelper.CollectionLogsProc);

            if(StreamBody != null)
            {
                model.DataReq = StreamBody.ReadToEndAsync().Result;

            }

            string? GuidD = HttpContextHelper.GetItem<string?>("Guid");

            if(GuidD == null)
            {
                GuidD = Guid.NewGuid().ToString();
                HttpContextHelper.SetItem("Guid", GuidD);
            }

            model.IdTrack = GuidD;
            model.DateT = DateTime.Now;

            collection.InsertOneAsync(model);
        }
    }
}
