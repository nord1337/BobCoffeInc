using BobCoffeInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace BobCoffeInc.Controllers
{
    public class AccountController : Controller
    {


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.username == model.username && u.password == model.password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.username, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.username == model.username);
                }
                if (user == null)
                {
                    
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { full_name = model.full_name,username=model.username, email = model.email, password = model.password, about=model.about });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.username == model.username && u.password == model.password).FirstOrDefault();
                    }
                    
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.username, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}