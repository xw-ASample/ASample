using ASample.EntityFramework.MySql.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShopMySql.IRepository.BaseRepository
{
    public interface  IBaseRepository <T>: IBasicEntityFrameworkRepository<T, Guid> where T : class
    {

    }
}
