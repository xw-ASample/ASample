using ASample.EntityFramework.Repository;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Permission.Service.Repositorys
{
    public interface IBaseEntityRepository<T,TKey> : IBasicEntityFrameworkEntityRepository<T, TKey> where T : Entity
    {

    }
}
