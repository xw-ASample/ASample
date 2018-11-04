using ASample.ByhShop.IRepository;
using ASample.EntityFramework.Repository;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.ByhShop.Repository
{
    public class BaseRepository<T>: BasicEntityFrameworkRepository<ASampleByhShopContext, T, Guid> where T : AggregateRoot
    {
    }
}
