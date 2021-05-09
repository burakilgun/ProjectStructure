using Nairobi.Data.Repositories.GenericRepository.MongoDb;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Entities;
using Nairobi.Settings;

namespace Nairobi.Data.Repositories
{
    public class ProductRepository : MongoDbRepositoryBase<Product>, IProductRespository
    {
        public ProductRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
