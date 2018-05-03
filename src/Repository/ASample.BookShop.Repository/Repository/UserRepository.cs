using ASample.BookShop.IRepository;
using ASample.BookShop.Model.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Repository
{
    public class UserRepository : BaseRepositroy<User>,IUserRepository
    {
    }
}
