using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nairobi.Entities.Base
{
    public abstract class MongoDbEntity : IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement(Order = 101)]
        public bool IsActive { get; set; } = true;

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 102)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 103)]
        public DateTime? UpdatedAt { get; set; }


        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement(Order = 104)]
        public bool IsDeleted { get; set; } = false;

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement(Order = 105)]
        public DateTime? DeletedAt { get; set; }
    }
}
