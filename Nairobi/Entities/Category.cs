using Nairobi.Entities.Base;

namespace Nairobi.Entities
{
    public class Category : MongoDbEntity
    {
        public string Name { get; set; }
    }
}
