using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportsStore.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("productID")]
        public int ProductID { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
    }
}