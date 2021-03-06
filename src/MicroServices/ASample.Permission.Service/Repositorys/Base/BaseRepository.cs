﻿using ASample.EntityFramework.Repository;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Repositorys
{
    public class BaseRepository <T>: BasicEntityFrameworkRepository<ASamplePermissionDbContext, T, Guid> where T : AggregateRoot
    {

    }
}