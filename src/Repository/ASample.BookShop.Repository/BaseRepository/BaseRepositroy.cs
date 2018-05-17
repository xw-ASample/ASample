using ASample.BookShop.Dal;
using ASample.BookShop.IRepository;
using ASample.EntityFramework.Repository;
using System;


namespace ASample.BookShop.Repository
{
    public class BaseRepositroy<T>:BasicEntityFrameworkRepository<ASampleBookShopContext, T, Guid> where T :class
    {
    }
}
