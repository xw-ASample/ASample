using ASample.EntityFramework.Repository;
using System;

namespace ASample.Crm.Dal.IBaseDal
{
    public interface IBaseRepository<T> : IBasicEntityFrameworkRepository<T, Guid> where T : class
    {
    }
}
