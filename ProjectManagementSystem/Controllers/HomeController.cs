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
using ProjectManagementSystem.ViewModel;

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
            var users = (from user in db.Users
                         select new
                         {
                             UserId = user.Id,
                             FirstName = user.FirstName,
                             Email = user.Email,
                             Roles = (from userRole in user.Roles
                                      join role in db.Roles on userRole.RoleId
                                      equals role.Id
                                      select role.Name).ToList()
                         }).ToList().Select(p=> new UsersWithRoles()
                         {
                             UserId = p.UserId,
                             FirstName = p.FirstName,
                             Email = p.Email,
                             Role = string.Join(", ",p.Roles)
                             
                         });
            return View("About", users);
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}