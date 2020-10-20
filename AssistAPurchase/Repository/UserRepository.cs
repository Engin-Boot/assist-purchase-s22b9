using AssistAPurchase.AssistAPurchase.DataBase;
using AssistAPurchase.Models;
using System.Collections.Generic;
namespace AssistAPurchase.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserModel> UserList = new List<UserModel>();

        public UserRepository()
        {
            var users = new UsersGetter().Users;
            foreach (UserModel user in users)
                Add(user);
        }

        private bool Find(string email)
        {
            foreach (UserModel userModel in UserList)
                if (userModel.Email == email)
                    return true;
            return false;
        }

        private void Add(UserModel user)
        {
            UserList.Add(user);
        }
        public bool Login(UserModel user)
        {
            foreach (UserModel userModel in UserList)
                if (userModel.Email == user.Email)
                    if(userModel.Password == user.Password)
                        return true;
                    else
                    {
                        return false;
                    }
            return false;
        }

        public bool SignUp(UserModel user)
        {
            var ifExist = Find(user.Email);
            if (!ifExist)
                Add(user);
            return !ifExist;
        }
    }
}
