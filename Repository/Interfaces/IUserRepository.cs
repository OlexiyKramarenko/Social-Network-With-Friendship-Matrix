using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByID(int id);
        List<User> GetUserList();
        void FriendRequest(int userId_1, int userId_2);
        void AddToFriends(int userId_1, int userId_2);
        List<User> GetUsersByIDs(List<int> ids);
        void RemoveFromFriends(int userId_1, int userId_2);
        bool AreFriends(int userId_1, int userId_2);
        List<int> GetNestedFriendIDs(int level, int anchorId, List<int> parentIds = null);
       
    }
}
