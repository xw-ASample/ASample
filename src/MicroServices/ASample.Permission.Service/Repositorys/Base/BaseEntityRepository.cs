using ASample.EntityFramework.Repository;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Repositorys
{
    public class BaseEntityRepository <T,TKey>: BasicEntityFrameworkEntityRepository<ASamplePermissionDbContext, T, TKey> where T : Entity
    {

    }
}