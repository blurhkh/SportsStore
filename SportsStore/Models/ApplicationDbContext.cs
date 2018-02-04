using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace SportsStore.Models
{
    public class ApplicationDbContext
    {
        private IMongoDatabase _db;
        public ApplicationDbContext(string connectionString, string databaseName)
            => _db = new MongoClient(connectionString).GetDatabase(databaseName);

        public IMongoCollection<Product> Products => _db.GetCollection<Product>("product");
        public IMongoCollection<Order> Orders => _db.GetCollection<Order>("order");
    }
}
