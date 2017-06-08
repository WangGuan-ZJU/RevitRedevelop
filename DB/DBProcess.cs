using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace RevitRedevelop.DB
{
    class DBProcess
    {
        public string databaseName = "";
        public string dcollectionName = "";
        public bool connect()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("UserInfo");
            return true;
        }
        public bool insert()
        {
            return true;
        }
        public bool insert()
        {
            return true;
        }
        public BsonDocument search()
        {
            return null;
        }
    }
}
