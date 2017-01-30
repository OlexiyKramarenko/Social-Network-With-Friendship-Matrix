using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendshipMatrix.Models
{
    public class UserViewmodel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserPageViewModel
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public List<string> FriendIDs { get; set; }
    }
}
