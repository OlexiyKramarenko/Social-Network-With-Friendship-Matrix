using FriendshipMatrix.Models;
using Repository;
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
    public class HomeController : Controller
    {
        IAccountService accountService;
        IUserRepository userRepository;
        public HomeController(IUserRepository userRepository, IAccountService accountService)
        {
            this.accountService = accountService;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public JsonResult GetUser(int? id)
        {
            int userId;

            if (id == null || id == 0)
                userId = accountService.GetCurrentUserId();
            else
                userId = id.Value;

            User user = userRepository.GetUserByID(userId);
            UserPageViewModel userVM = null;
            if (user != null)
                userVM = new UserPageViewModel
                {
                    Avatar = user.Avatar,
                    UserName = user.UserName
                };
            else
                userVM = new UserPageViewModel
                {
                    UserName = "Why not start with registration?"
                };
        
            
            return Json(new { userVM }, JsonRequestBehavior.AllowGet);
        }

    }
}