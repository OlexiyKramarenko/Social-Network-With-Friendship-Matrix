using Repository.Interfaces;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        DataBaseContext db = null;
        public AccountRepository()
        {
            db = new DataBaseContext();
        }
        public OperationResult CreateUser(string username, string passwordHash)
        {
            db.Users.Add(
                new User
                {
                    UserName = username,
                    Password = passwordHash,
                    Avatar = "/Content/avatars/default.jpg"
                });

            int result = db.SaveChanges();
            if (result > 0)
                return new OperationResult { Succeded = true };
            else
                return new OperationResult { Succeded = false };
        }
        public User GetUserByID(int id)
        {
            User user = db.Users.Find(id);
            return user;
        }
        public User GetUser(string username)
        {
            User user = db.Users.FirstOrDefault(a => a.UserName == username);
            return user;
        }
    }
}
