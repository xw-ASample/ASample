﻿using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using System;

namespace ASample.Permission.Service.Services
{
    public class AdminRoleService:BaseService<AdminRole,Guid>
    {

        public AdminRoleService()
        {
            CurrentRepository = new AdminRoleRepository();
        }
    }
}