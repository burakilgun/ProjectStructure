using System.Threading.Tasks;
using MongoDB.Driver;
using Nairobi.Data.Repositories.Interfaces;
using Nairobi.Entities;

namespace Nairobi.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDataContext _dataContext;

        public CategoryRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Category> GetById(string id)
        {
            return await _dataContext.Categories.Find(p=> p.Id == id).FirstOrDefaultAsync();
        }
    }
}
