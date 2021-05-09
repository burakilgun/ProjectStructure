using System;
using Nairobi.Entities.Base;

namespace Nairobi.Entities
{
    public class Product : MongoDbEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
