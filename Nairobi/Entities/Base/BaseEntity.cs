using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nairobi.Entities.Base
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
