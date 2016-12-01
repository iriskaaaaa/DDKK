using AgileEnglish.Models.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AgileEnglish.Models.DataProvider
{
    public class MongoDbProvider
    {
        private static MongoDbProvider instance;

        public IMongoCollection<BsonDocument> UsersRepository
        {
            get;
            private set;
        }

        private MongoDbProvider()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("AgileEnglish");
            UsersRepository = database.GetCollection<BsonDocument>("users");
        }

        public static MongoDbProvider Get
        {
            get
            {
                if (instance == null)
                {
                    instance = new MongoDbProvider();
                }
                return instance;
            }
        }
    }
}