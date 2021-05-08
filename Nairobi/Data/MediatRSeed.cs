using System.Collections.Generic;
using MongoDB.Driver;
using Nairobi.Entities;

namespace Nairobi.Data
{
    public class MediatRSeed
    {
        public static void SeedCategories(IMongoCollection<Category> categories)
        {
            var exist = categories.Find(p => true).Any();
            if (!exist)
            {
                categories.InsertManyAsync(GenerateCategories());
            }
        }

        private static IEnumerable<Category> GenerateCategories()
        {
            return new List<Category>
            {
                new Category{Name = "Buzdolabı"},
                new Category{Name = "Çamaşır Makinesi"},
                new Category{Name = "Bulaşık Makinesi"},
                new Category{Name = "Televizyon"},
                new Category{Name = "Telefon"},
                new Category{Name = "Bilgisayar"}
            };
        }
    }
}
