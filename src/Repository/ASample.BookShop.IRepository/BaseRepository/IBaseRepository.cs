using ASample.EntityFramework.Repository;
using System;


namespace ASample.BookShop.IRepository
{
    public interface IBaseRepository<T>  : IBasicEntityFrameworkRepository<T, Guid> where T :class
    {

    }
}
