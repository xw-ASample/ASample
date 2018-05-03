using ASample.BookShop.IRepository;
using ASample.BookShop.IService;
using ASample.BookShop.Model;

namespace ASample.BookShop.Service
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
