using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirAstanaService.Models;
using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirAstanaService.Controllers
{
    public class UserController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public UserController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _repoWrapper.User.FindByCondition(u => u.Email == model.Email).FirstOrDefault();
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password };
                    Role userRole = _repoWrapper.Role.FindByCondition(r => r.Name == "user").FirstOrDefault();
                    if (userRole != null)
                        user.Role = userRole;

                    _repoWrapper.User.Insert(user);
                    _repoWrapper.Save();

                    Authenticate(user);

                    return RedirectToAction("Index", "Flight");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _repoWrapper.User.FindByCondition(u => u.Email == model.Email && u.Password == model.Password).Include(p=>p.Role).FirstOrDefault();
                
                if (user != null)
                {
                    Authenticate(user);

                    return RedirectToAction("Index", "Flight");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Flight");
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult UserAccount()
        {
            string userName = HttpContext.User.Identity.Name;
            return View((object)userName);
        }

        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
       
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
     
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
