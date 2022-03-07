using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace sandbox.web.api.Models
{
    [BsonIgnoreExtraElements]
    public class Token
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("id")]
        public string id { get; set; }
        [BsonElement("symbol")]
        public string symbol { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("image")]
        public string image { get; set; }
        [BsonElement("current_price")]
        public double current_price { get; set; }
        [BsonElement("market_cap")]
        public Int64 market_cap { get; set; }
        [BsonElement("market_cap_rank")]
        public int market_cap_rank { get; set; }
    }
}
