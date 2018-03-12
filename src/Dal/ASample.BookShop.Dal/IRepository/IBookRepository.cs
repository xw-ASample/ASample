using ASample.BookShop.Dal.Models;
using ASample.EntityFramework.Repository;
using System;

namespace ASample.BookShop.Dal.IRepository
{
    public interface IBookRepository : IBasicEntityFrameworkRepository<Book,Guid>
    {

    }
}
