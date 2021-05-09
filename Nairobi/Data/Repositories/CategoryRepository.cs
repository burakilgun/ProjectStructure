using Nairobi.Data.Repositories.GenericRepository.MongoDb;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Entities;
using Nairobi.Settings;

namespace Nairobi.Data.Repositories
{
    public class CategoryRepository : MongoDbRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
