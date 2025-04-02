using MongoDB.Bson.Serialization.Attributes;

namespace ApiSolcaClase.Helpers.Models.MongoModels
{
    public class LogProcesMongoModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string IdTrack { get; set; }
        public string Process { get; set; }
        public object DataReq { get; set; }
        public string Message { get; set; }
        [BsonElement("DateTime")]
        public DateTime DateT { get; set; }
    }
}
