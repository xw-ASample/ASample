using ASample.Crm.IRepository;
using ASample.EntityFramework.Repository;
using System;

namespace ASample.Crm.Repository
{
    public class BaseRepository<T> : BasicEntityFrameworkRepository<ASampleCrmContext, T, Guid> where T : class
    {
    }
}
