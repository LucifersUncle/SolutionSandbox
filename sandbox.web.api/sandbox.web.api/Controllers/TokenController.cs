using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using sandbox.web.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.web.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private IMongoCollection<Token> _tokenCollection;

        public TokenController(IMongoClient client)
        {
            var db = client.GetDatabase("PortfolioManager");
            _tokenCollection = db.GetCollection<Token>("tokens");
        }

        [HttpGet]
        public IEnumerable<Token> Get()
        {
            return _tokenCollection.Find(t => t.current_price > 100.0).ToList();
        }
    }
}
