using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using ASample.Permission.Service.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Permission.Service.Infrastructure
{
    public class ASamplePermissionUserStore : IUserLockoutStore<IdentityUser, Guid>,
        IUserPasswordStore<IdentityUser, Guid>,
        IUserTwoFactorStore<IdentityUser, Guid>,
        IUserEmailStore<IdentityUser, Guid>,
        IUserLoginStore<IdentityUser, Guid>,
        IUserStore<IdentityUser, Guid>
    {

        private IdentityUserService IdentityUserService { get; set; }

        private IdentityPasswordService IdentityPasswordService { get; set; }
        public ASamplePermissionUserStore()
        {
            IdentityUserService = new IdentityUserService();
            IdentityPasswordService = new IdentityPasswordService();
        }
        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(IdentityUser user)
        {
            await IdentityUserService.AddAsync(user);
        }

        public async Task UpdateAsync(IdentityUser user)
        {
            await IdentityUserService.UpdateAsync(user);
            //await IdentityUserRepository.Commit();
        }

        public async Task DeleteAsync(IdentityUser user)
        {
            await IdentityUserService.DeleteAsync(user.Id);
            //await IdentityUserRepository.Commit();
        }

        public async Task<IdentityUser> FindByIdAsync(Guid userId)
        {
            var result = await IdentityUserService.GetByUserIdAsync(userId);
            return result;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var result = await IdentityUserService.GetByNameAsync(userName);
            return result;
        }

        public async Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            var result = await IdentityPasswordService.GetPasswordByUserId(user.Id);
            return result.PasswordHash;
        }

        public async Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            //修改密码时
            var identityPassword = await IdentityPasswordService.GetPasswordByUserId(user.Id);
            if (identityPassword != null)
            {
                var command = new IdentityPassword
                {
                    //Id = identityPassword.Id,
                    UserId = user.Id,
                    PasswordHash = passwordHash,
                };
                await IdentityPasswordService.UpdateAsync(command);
            }
            //添加用户时
            else
            {
                var command = new IdentityPassword
                {
                    UserId = user.Id,
                    PasswordHash = passwordHash,
                    Salt = Guid.NewGuid().ToString()
                };
                await IdentityPasswordService.AddAsync(command);
            }
            //await IdentityPasswordRepository.Commit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(IdentityUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }
    }
}