using ASample.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Dal.Base
{
    public class BaseRepositroy<T>:BasicEntityFrameworkRepository<ASampleBookShopContext, T, Guid> where T :class
    {
    }
}
