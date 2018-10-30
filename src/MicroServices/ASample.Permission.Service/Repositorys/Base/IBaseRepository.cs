using ASample.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Permission.Service.Repositorys
{
    public interface IBaseRepository<T> : IBasicEntityFrameworkRepository<T, Guid> where T : class
    {

    }
}
