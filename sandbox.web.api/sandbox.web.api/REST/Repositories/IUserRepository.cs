using sandbox.web.api.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sandbox.web.api.REST.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
