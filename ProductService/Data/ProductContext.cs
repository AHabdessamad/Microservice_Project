
using MongoDB.Driver;
using ProductService.Models;
using Microsoft.Extensions.Configuration;

namespace ProductService.Data
{
    public class ProductContext 
    {

        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;

        public ProductContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase? Database => _database;

    }
}