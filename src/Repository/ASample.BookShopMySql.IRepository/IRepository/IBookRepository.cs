using ASample.BookShop.Model;
using ASample.BookShopMySql.IRepository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShopMySql.IRepository.IRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {

    }
}
