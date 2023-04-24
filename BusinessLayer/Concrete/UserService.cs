using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _aboutDal;

        public UserService(IUserDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = _aboutDal.Get(x => x.UserName == userName && x.Password == password);
            return user;
        }
    }
}
