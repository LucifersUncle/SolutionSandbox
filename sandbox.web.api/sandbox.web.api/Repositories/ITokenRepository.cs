using MongoDB.Bson;
using sandbox.web.api.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sandbox.web.api.Repositories
{
    public interface ITokenRepository
    {
        Task<IEnumerable<Token>> GetAllTokens();
        Task<IEnumerable<Token>> GetTokenById(ObjectId id);

    }
}
