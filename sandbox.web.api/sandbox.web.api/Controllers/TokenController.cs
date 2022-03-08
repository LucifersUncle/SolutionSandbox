using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using sandbox.web.api.Models;
using sandbox.web.api.Repositories;
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
        /// <summary>
        /// Dependency Injection
        /// </summary>
        private ITokenRepository _tokenRepository;
        private IMongoCollection<Token> _tokenCollection;

        public TokenController(IMongoClient client)
        {
            //DB setup, perhaps should be in the repository
            var db = client.GetDatabase("PortfolioManager");
            _tokenCollection = db.GetCollection<Token>("tokens");

            _tokenRepository = new TokenRepository();
        }



        [HttpGet]
        public IEnumerable<Token> GetAllTokens()
        {
            return _tokenCollection.Find(t => t.current_price > 0).ToList();
        }

        public Task<IEnumerable<Token>> GetTokenById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Token> GetTokenByName(string name)
        //{
        //    var filter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>();
        //}

        #region Methods
        

        #endregion
    }
}
