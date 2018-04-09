using ASample.BookShop.Dal.Base;
using ASample.BookShop.Dal.IRepository;
using ASample.BookShop.Dal.Models;
using ASample.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Dal.Respository
{
    public class BookRepository : BaseRepositroy<Book>,IBookRepository
    {

    }
}
