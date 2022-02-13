using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.web.app.Models
{
    public class Token
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public double Current_Price { get; set; }
        public string MarketCap { get; set; }
        public int Market_Cap_Rank { get; set; }
    }
}
