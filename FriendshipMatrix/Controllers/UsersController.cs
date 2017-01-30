using Repository.Interfaces;
using Repository.POCO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendshipMatrix.Controllers
{
    public class UsersController : Controller
    {
        IAccountService accountService;
        IUserRepository userRepository;
        public UsersController(IUserRepository userRepository, IAccountService accountService)
        {
            this.userRepository = userRepository;
            this.accountService = accountService;
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            List<User> users = userRepository.GetUserList();
            return Json(new { users }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CurrentUserStatus(int? id)
        { 
            //Role of current visitor 
            string Role = "";

            if (id.HasValue && id == 0)                        
                Role = "admin";            
            else
            {
                int currentUserId = accountService.GetCurrentUserId();

                if (id.HasValue && id != currentUserId)
                {
                    bool areFriends = userRepository.AreFriends(id.Value, currentUserId);
                    if (areFriends)
                        Role = "friend";
                    else
                        Role = "unknown";
                }
            }
            return Json(new { Role  }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SendFriendRequest(int id)
        {
            int currentUserId = accountService.GetCurrentUserId();
            userRepository.FriendRequest(currentUserId, id);
            return new EmptyResult();
        }
        [HttpGet]
        public ActionResult AddToFriends(int id)
        {
            int currentUserId = accountService.GetCurrentUserId();
            userRepository.AddToFriends(currentUserId, id);
            return new EmptyResult();
        }
        [HttpGet]
        public ActionResult RemoveFromFriends(int id)
        {
            int currentUserId = accountService.GetCurrentUserId();
            userRepository.RemoveFromFriends(currentUserId, id);
            return new EmptyResult();
        }
        [HttpGet]
        public JsonResult GetFriendsTree(int id, int level = 1)
        {
            if (id == 0)
                id = accountService.GetCurrentUserId();

            List<int> ids = userRepository.GetNestedFriendIDs(level, id);
            List<User> users = userRepository.GetUsersByIDs(ids);

            return Json(new { users }, JsonRequestBehavior.AllowGet);
        }
    }
}