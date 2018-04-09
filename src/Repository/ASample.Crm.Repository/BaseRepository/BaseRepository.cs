using ASample.EntityFramework.Repository;
using System;

namespace ASample.Crm.Dal.Impl.BaseDalImpl
{
    public class BaseRepository<T> : BasicEntityFrameworkRepository<ASampleCrmContext, T, Guid> where T : class
    {
    }
}
