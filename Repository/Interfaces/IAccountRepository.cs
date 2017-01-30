using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountRepository
    {
        OperationResult CreateUser(string username, string password);
        User GetUser(string username);
    }
}
