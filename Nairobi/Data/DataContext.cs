using MongoDB.Driver;
using Nairobi.Entities;
using Nairobi.Settings;

namespace Nairobi.Data
{
    public class DataContext : IDataContext
    {
        public DataContext(IMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Products = database.GetCollection<Product>(nameof(Product));
            Categories = database.GetCollection<Category>(nameof(Category));

            NairobiSeed.SeedCategories(Categories);
        }

        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
    }
}
