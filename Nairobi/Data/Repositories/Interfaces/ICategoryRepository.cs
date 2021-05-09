using System.Threading.Tasks;
using Nairobi.Data.Repositories.GenericRepository;
using Nairobi.Entities;

namespace Nairobi.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category,string>
    {
    }
}
