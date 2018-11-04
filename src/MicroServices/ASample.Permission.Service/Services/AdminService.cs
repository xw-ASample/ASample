using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;

namespace ASample.Permission.Service.Services
{
    public class AdminService:BaseService<Admin>
    {

        public AdminService()
        {
            CurrentRepository = new AdminRepository();
        }
    }
}