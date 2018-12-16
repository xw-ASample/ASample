using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Permission.Service.Services
{
    public class IdentityUserService:BaseService<IdentityUser>
    {
        public IdentityUserService()
        {
            CurrentRepository = new IdentityUserRepository();
        }

        public async Task<IdentityUser> GetByUserIdAsync(Guid userId)
        {
            var result = CurrentRepository._dbSet.FirstOrDefault(c => c.Id == userId);
            return result;
        }

        public async Task<IdentityUser> GetByNameAsync(string name)
        {
            var result = CurrentRepository._dbSet.FirstOrDefault(c => c.UserName == name);
            return result;
        }
    }
}