using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.Permission.Service.Services
{
    public class IdentityPasswordService : BaseService<IdentityPassword>
    {
        public IdentityPasswordService()
        {
            CurrentRepository = new IdentityPasswordRepository();
        }

        public async Task<IdentityPassword> GetPasswordByUserId(Guid userId)
        {
            var result = CurrentRepository._dbSet.FirstOrDefault(c =>c.UserId==userId);
            return result;
        }

        public async Task<IdentityPassword> SetPasswordByUserId(Guid userId)
        {
            var result = CurrentRepository._dbSet.FirstOrDefault(c => c.UserId == userId);
            return result;
        }
    }
}