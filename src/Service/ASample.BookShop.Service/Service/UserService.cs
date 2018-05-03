using ASample.BookShop.IRepository;
using ASample.BookShop.IService;
using ASample.BookShop.Model.AggregateRoots;

namespace ASample.BookShop.Service
{
    public class UserService:BasicService<User>,IUserService
    {
        IUserRepository UserRepository;
        public UserService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
            base.CurrentRepository = userRepository;
        }
    }
}
