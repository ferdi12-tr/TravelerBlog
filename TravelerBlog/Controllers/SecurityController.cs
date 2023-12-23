using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerBlog.Entity;
using TravelerBlog.Models;

namespace TravelerBlog.Controllers
{
    public class SecurityController : Controller
    {
        UserProcess _userProcess = new UserProcess();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var user = _userProcess.GetAll().Find(x => x.Email == Email && x.Password == Password);
            if (user == null)
            {
                return RedirectToAction("Register", "Security");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Username, string Email, string Password)
        {
            User user = new User()
            {
                UserName = Username,
                Email = Email,
                Password = Password,
                UserCreatedDate = DateTime.Now,
                RoleId = 2
            };

            _userProcess.Add(user);
            return RedirectToAction("Index", "Home");
        }

    }
}