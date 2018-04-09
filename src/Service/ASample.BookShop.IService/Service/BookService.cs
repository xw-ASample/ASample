using ASample.BookShop.Dal.IRepository;
using ASample.BookShop.Dal.Models;
using ASample.BookShop.Service.BasicService;
using ASample.BookShop.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Service.Service
{
    public class BookService : BasicService<Book>, IBookService
    {
        IBookRepository BookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.BookRepository = bookRepository;
            base.CurrentRepository = bookRepository;
        }
    }
}
