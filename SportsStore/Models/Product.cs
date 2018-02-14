using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("productId")]
        public int ProductId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("cartLine")]
        public List<CartLine> CartLine { get; set; }
    }
}