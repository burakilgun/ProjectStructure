using MongoDB.Driver;
using Nairobi.Entities;

namespace Nairobi.Data
{
    public interface IDataContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<Category> Categories { get; }
    }
}
