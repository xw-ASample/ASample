using ASample.BookShop.IRepository;
using ASample.BookShop.IRepository.Models;
using ASample.BookShop.Model;
using ASample.BookShop.Repository;
using ASample.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.DalImpl.Respository
{
    public class BookRepository : BaseRepositroy<Book>,IBookRepository
    {

    }
}
