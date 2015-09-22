using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Repositories.Interfaces;

namespace Entities.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
