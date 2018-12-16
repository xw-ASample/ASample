using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.Permission.Service.Services
{
    public class AdminService:BaseService<Admin>
    {

        public AdminService()
        {
            CurrentRepository = new AdminRepository();
        }

        public async Task<Admin> GetByIdAsync(Guid id)
        {
            var result = await CurrentRepository.SelectAsync(c => c.Id == id);
            return result.FirstOrDefault();
        }
    }
}