using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductService.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set;}
        [BsonElement("Name")]
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set;}

        public string? Brand { get; set; }
        public string? Price { get; set; }
        public string? ImageFile { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public float? Rating { get; set;}

        
    }
}