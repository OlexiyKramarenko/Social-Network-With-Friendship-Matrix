using Repository.Interfaces;
using Repository.POCO;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Web;
using System.Linq;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Collections;
using System.Collections.Generic;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public bool CreateUser(string username, string password)
        {
            var hash = SecurePasswordHasher.Hash(password);
            OperationResult result = accountRepository.CreateUser(username, hash);
            return result.Succeded;
        }

        public int GetCurrentUserId()
        {
            int currentUserId;
            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = claimsIdentity.Claims;
            var NameIdentifier = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
            int.TryParse(NameIdentifier, out currentUserId);
            return currentUserId;
        }
        public void Logout()
        {
            AuthenticationManager.SignOut();
        }
        public void Login(int userId, string username)
        {
            ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie",
                                                              ClaimsIdentity.DefaultNameClaimType,
                                                              ClaimsIdentity.DefaultRoleClaimType);

            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
            claim.AddClaim(new Claim(ClaimTypes.Name, username));

            claim.AddClaim(new Claim(
            "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                                  "OWIN Provider",
                                  ClaimValueTypes.String));

            AuthenticationManager.SignOut();
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);
        }
        public User GetUser(string username, string password)
        {
            var hash = SecurePasswordHasher.Hash(password);
            User user = accountRepository.GetUser(username);
            if (user != null)
            {
                bool result = SecurePasswordHasher.Verify(password, user.Password);
                if (result)
                    return user;
            }
            return null;
        }


    }
}
