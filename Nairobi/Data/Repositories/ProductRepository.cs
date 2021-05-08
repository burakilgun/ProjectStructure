using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Entities;

namespace Nairobi.Data.Repositories
{
    public class ProductRepository : IProductRespository
    {
        private readonly IDataContext _dataContext;

        public ProductRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _dataContext.Products.Find(p => true).ToListAsync();
            return products;
        }

        public async Task<string> CreateAsync(Product product)
        {
           await _dataContext.Products.InsertOneAsync(product);
           return product.Id;
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return  await _dataContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAsycn(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _dataContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
