using ProjectManager.Entities;
using ProjectManager.Repos;
using ProjectManager.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        // Index
        public ActionResult Index()
        {
            return View();
        }

        // Login Get
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginM());
        }

        // Login Post
        [HttpPost]
        public ActionResult Login(LoginM model)
        {
            // Model validation.
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            // Authentication validation.
            UsersRepo usersRepo = new UsersRepo();
            User user = usersRepo.GetFirstOrDefault(u => u.Username == model.Username &&
                                                u.Password == model.Password);

            // In case of invalid authentication.
            if(user == null)
            {
                ModelState.AddModelError("authFailed", "Invalid username or password!");
                
                return View(model);
            }

            // In case of valid authentication.
            Session["loggedUser"] = user;
            
            return RedirectToAction("Index", "Home");
            
        }

        // Logout
        public ActionResult Logout()
        {
            Session["loggedUser"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}