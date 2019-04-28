using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.Entity;

namespace ProjectManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Customer"))
            {
                return View("Index");
            }
            return View("otherUsers");
            
        }

        public ActionResult About()
        {
            var userStore = new UserStore<User>(db);
            var manager = new UserManager<User>(userStore);
            var user = User.Identity;
            var users = db.Users.Include(p => p.Roles);
            var roles = manager.GetRoles(user.GetUserId());
            return View("About", users.ToList());
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}