using ASample.Crm.Dal.IBaseDal;
using ASample.Crm.Dal.Impl.BaseDalImpl;
using ASample.Crm.Dal.IRepository;
using ASample.Crm.Model.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Crm.Dal.Impl.Repository
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
    }
}
