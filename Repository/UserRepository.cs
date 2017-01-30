using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Repository.POCO;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        DataBaseContext db = null;
        public UserRepository()
        {
            db = new DataBaseContext();
        }
        public bool AreFriends(int userId_1, int userId_2)
        {
            Friendship f = db.Friends.FirstOrDefault(a => a.IdFirst == userId_1 && a.IdSecond == userId_2);
            if (f == null)
                f = db.Friends.FirstOrDefault(a => a.IdFirst == userId_2 && a.IdSecond == userId_1);

            if (f != null)
                return true;
            return false;
        }

        public void FriendRequest(int senderId, int recipientId)
        {
            db.FriendRequests.Add(new FriendRequest { SenderUserId = senderId, RecipientUserId = recipientId });
            db.SaveChanges();
        }
        public void AddToFriends(int userId_1, int userId_2)
        {
            db.Friends.Add(new Friendship { IdFirst = userId_1, IdSecond = userId_2 });
            var request = db.FriendRequests.FirstOrDefault(a => (a.SenderUserId == userId_1 && a.RecipientUserId == userId_2) || (a.SenderUserId == userId_2 && a.RecipientUserId == userId_1));
            if (request != null)
                db.FriendRequests.Remove(request);
            db.SaveChanges();
        }

        public void RemoveFromFriends(int userId_1, int userId_2)
        {
            Friendship f = db.Friends.FirstOrDefault(a => a.IdFirst == userId_1 && a.IdSecond == userId_2);
            if (f == null)
                f = db.Friends.FirstOrDefault(a => a.IdFirst == userId_2 && a.IdSecond == userId_1);

            if (f != null)
                db.Friends.Remove(f);

            db.SaveChanges();
        }
        public User GetUserByID(int id)
        {
            var user = db.Users.Find(id);
            return user;
        }
        public List<User> GetUsersByIDs(List<int> ids)
        {
            List<User> users = (from u in db.Users
                                where ids.Any(id => u.ID.Equals(id))
                                select u).ToList();
            return users;
        }
        public List<User> GetUserList()
        {
            List<User> users = db.Users.Select(u => new { Avatar = u.Avatar, ID = u.ID, UserName = u.UserName }).AsEnumerable()
                                       .Select(u => new User { Avatar = u.Avatar, ID = u.ID, UserName = u.UserName }).ToList();

            return users;
        }

        private List<int> result = new List<int>();
        private int prevResult = -1;
        public List<int> GetNestedFriendIDs(int levels, int anchorUserID, List<int> parentIds)
        {
            if (parentIds == null)
                parentIds = new List<int> { anchorUserID };

            if (result.Count > prevResult)//to exclude useless iterations
            {
                prevResult = result.Count;

                if (levels > 0)
                {
                    var childIds = new List<int>();

                    foreach (int id in parentIds)
                        childIds.AddRange(GetFriendIDsOfSingleUser(id));

                    foreach (int id in childIds)
                        if (!result.Contains(id))
                            result.Add(id);

                    GetNestedFriendIDs(--levels, anchorUserID, childIds);
                }
            }
            result.Remove(anchorUserID);
            return result;
        }
        private List<int> GetFriendIDsOfSingleUser(int userId)
        {
            int[] IDs_1 = db.Friends.Where(a => a.IdFirst == userId).Select(a => a.IdSecond).ToArray();
            int[] IDs_2 = db.Friends.Where(a => a.IdSecond == userId).Select(a => a.IdFirst).ToArray();
            var list = new List<int>();
            list.AddRange(IDs_1);
            list.AddRange(IDs_2);
            return list;
        }
    }
}
