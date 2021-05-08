using System.Threading.Tasks;
using Nairobi.Entities;

namespace Nairobi.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(string id);
    }
}
