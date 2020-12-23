using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DishesTask.Models
{
    /// <summary>
    /// Das Model für die Gerichte.
    /// </summary>
    public class Dishes
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("garnish")]
        public string Garnish { get; set; }

        [BsonElement("short_description")]
        public string ShortDescription { get; set; }

        [BsonElement("price")]
        public string Price { get; set; }

        [BsonElement("category")]
        public List<Category> Category { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }

        [BsonElement("availability")]
        public List<Availability> Availability { get; set; }

        [BsonElement("approx_waiting_time")]
        public string ApproxWaitingTime { get; set; }

        [BsonElement("stock")]
        public string Stock { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }
    }

    public class Availability
    {
        [BsonElement("weekdays")]
        public List<string> Weekdays { get; set; }

        [BsonElement("weekend")]
        public List<string> Weekend { get; set; }
    }

    public class Category
    {
        [BsonElement("type")]
        public string Type { get; set; }
    }
}