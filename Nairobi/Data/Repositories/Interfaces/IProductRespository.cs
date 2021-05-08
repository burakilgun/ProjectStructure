using System.Collections.Generic;
using System.Threading.Tasks;
using Nairobi.Entities;

namespace Nairobi.Data.Repositories.Interfaces
{
    public interface IProductRespository
    {
        Task<List<Product>> GetAllAsync();

        Task<string> CreateAsync(Product product);
        Task<Product> GetByIdAsync(string id);
        Task<bool> DeleteAsycn(string id);
    }
}
