using ASample.Crm.IRepository;
using ASample.Crm.Model.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Crm.Repository
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
    }
}
