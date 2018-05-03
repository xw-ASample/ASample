using ASample.Crm.IRepository;
using ASample.Crm.IServices;
using ASample.Crm.Model.AggregateRoots;

namespace ASample.Crm.Service
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
