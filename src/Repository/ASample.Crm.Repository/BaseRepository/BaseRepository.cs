using ASample.Crm.IRepository;
using ASample.EntityFramework.Repository;
using ASmaple.Domain.Models;
using System;

namespace ASample.Crm.Repository
{
    public class BaseRepository<T> : BasicEntityFrameworkRepository<ASampleCrmContext, T, Guid> where T : AggregateRoot
    {
    }
}
