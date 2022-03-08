using MongoDB.Bson;
using sandbox.web.api.Models;
using sandbox.web.api.REST.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sandbox.web.api.REST.Data_Access
{
    public class TokenRepository : ITokenRepository
    {
        public Task<IEnumerable<Token>> GetAllTokens()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Token>> GetTokenById(ObjectId id)
        {
            throw new System.NotImplementedException();
        }
    }
}
