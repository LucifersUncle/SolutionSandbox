using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
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
        public IEnumerable<Token> GetAllTokens()
        {
            return _tokenCollection.Find(t => t.current_price > 0).ToList();
        }

        [HttpGet("{name}")]
        public Task<string> GetByName(string name)
        {
            Token token = new Token();

            var filter = Builders<BsonDocument>.Filter.Eq("name", name);
            var result = _tokenCollection.Find(filter.ToString().ToLower());
            return (Task<string>)result;
        }
    }
}
