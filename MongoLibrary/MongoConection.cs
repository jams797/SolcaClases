using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLibrary
{
    public class MongoConection
    {
        MongoClient _client;
        public IMongoDatabase dbMongo;

        public MongoConection(string ConectionDB, string NameDatabase)
        {
            _client = new MongoClient(ConectionDB);

            dbMongo = _client.GetDatabase(NameDatabase);
        }
    }
}
