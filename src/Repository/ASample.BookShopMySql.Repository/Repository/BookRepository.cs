using ASample.BookShop.Model;
using ASample.BookShopMySql.IRepository.IRepository;
using ASample.BookShopMySql.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShopMySql.Repository.Repository
{
    public class BookRepository : BaseRepositroy<Book>, IBookRepository
    {
    }
}
