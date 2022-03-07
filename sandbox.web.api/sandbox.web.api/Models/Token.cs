using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.web.api.Models
{
    public class Token
    {
        [BsonId]
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
        public string marketCap { get; set; }
        [BsonElement("market_cap_rank")]
        public int market_cap_rank { get; set; }
    }
}
