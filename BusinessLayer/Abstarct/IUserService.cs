using EntityLayer.Concrete;
using System.Threading.Tasks;

namespace BusinessLayer.Abstarct
{
    public interface IUserService
    {
        Task<User> Login(string userName, string password);
    }
}
