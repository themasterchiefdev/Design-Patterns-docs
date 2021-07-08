using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Shared.Models;
namespace Samples.Shared.Interfaces
{
    /*
     * This interface can be shared across the projects
     * as the implementation detail varies from project to Project
     */
    public interface IUserRepository
    {
        ValueTask<IEnumerable<User>> GetUsers();
    }
}
