using ASample.Crm.Dal.IRepository;
using ASample.Crm.Model.AggregateRoots;
using ASample.Crm.Service.Impl.BaseService;
using ASample.Crm.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.Crm.Service.Impl.Service
{
    public class UserService : BaseService<User>,IUserService
    {
        private IUserRepository UserRepository { get; set; }
        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
            CurrentRepository = userRepository;
        }
    }
}
