using ASample.Permission.Service.IServices;
using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Services
{
    public class AdminService:BaseService<Admin>,IAdminService
    {

    }
}