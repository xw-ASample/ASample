using ASample.BookShopMySql.IRepository;
using ASample.EntityFramework.MySql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShopMySql.Repository.BaseRepository
{
    public class BaseRepositroy<T> : BasicEntityFrameworkRepository<ASampleBookShopContext, T, Guid> where T : class
    {
    }
}
