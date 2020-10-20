using AssistAPurchase.Models;

namespace AssistAPurchase.Repository
{
    public interface IUserRepository
    {
        public bool Login(UserModel user);
        public bool SignUp(UserModel user);
    }
}
