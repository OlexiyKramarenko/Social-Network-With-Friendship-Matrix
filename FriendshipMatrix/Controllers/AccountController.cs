using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using FriendshipMatrix.Models;
using Repository.Interfaces;
using Services.Interfaces;
using Repository.POCO;

namespace FriendshipMatrix.Controllers
{

    public class AccountController : Controller
    {
        IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public JsonResult Login(UserViewmodel model)
        {
            bool Succeded = false;
            User user = accountService.GetUser(model.UserName, model.Password);
            if (user != null)
            {
                accountService.Login(user.ID, user.UserName);
                Succeded = true;
            }

            return Json(new { Succeded }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Register(UserViewmodel model)
        {
            bool Succeded = accountService.CreateUser(model.UserName, model.Password);

            return Json(new { Succeded }, JsonRequestBehavior.AllowGet);
        }

    }
}