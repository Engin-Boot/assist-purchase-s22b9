using AssistAPurchase.Models;
using System;
using System.Collections.Generic;

namespace AssistAPurchase.AssistAPurchase.DataBase
{
    public class UsersGetter
    {
        public List<UserModel> Users { get; private set; }

        public UsersGetter()
        {

            this.GetAllItems();
            Console.WriteLine(Users.Count);

        }
        private void GetAllItems()
        {
            List<UserModel> usersList = new List<UserModel>
            {
                new UserModel
                {
                    
                    Password = "gagan",
                    Email = "gagan@gmail.com"
                },
                new UserModel
                {
                    
                    Password = "kavya",
                    Email = "kavya@gmail.com"
                },

            };
            this.Users = usersList;
            }       
    }
}
