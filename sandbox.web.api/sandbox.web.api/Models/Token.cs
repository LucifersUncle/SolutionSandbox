using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.web.api.Models
{
    public class Token
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        [Required]
        public string name { get; set; }
        public string image { get; set; }
        public double current_price { get; set; }
        public string MarketCap { get; set; }
        public int Market_Cap_Rank { get; set; }
    }
}
