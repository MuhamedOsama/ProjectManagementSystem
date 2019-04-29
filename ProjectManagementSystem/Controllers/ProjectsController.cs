using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Logger;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ILog _ILog;
        public ProjectsController()
        {
            _ILog = Log.GetInstance;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: Projects

        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Customer);
            if (User.IsInRole("Customer"))
            {

                return PartialView("_ListProjects", projects.ToList());
            }
            else if(User.IsInRole("ProjectManager"))
            {
                var ProjectManagerId = User.Identity.GetUserId();
                var pm = db.Users.Include(m => m.Projects).FirstOrDefault(m => m.Id == ProjectManagerId);
                return PartialView("_ProfileView", projects.Where(m => m.UserId == ProjectManagerId).ToList());
            }
            else if(User.IsInRole("Admin"))
            {
                return PartialView("_AdminPosts", projects.ToList());
            }
            return PartialView("_nonCustomerView", projects.Where(m => m.UserId == null).ToList());
        }
        
        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        
        public ActionResult Create()
        {
            var project = new Project();
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName");
            return PartialView("_CreateProject", project); 
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CustomerId,CreatedAt")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatedAt = DateTime.Now;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName", project.CustomerId);
            return RedirectToAction("Index","Home");
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName", project.CustomerId);
            return View("Edit",project);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CustomerId,CreatedAt")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "FirstName", project.CustomerId);
            return RedirectToAction("Index","Home");
        }

       
        
        public ActionResult Assign(int id)
        {
            var ProjectManagerId = User.Identity.GetUserId();

            var userStore = new UserStore<User>(db);
            var manager = new UserManager<User>(userStore);
            var pm = db.Users.Include(m=>m.Projects).FirstOrDefault(m=>m.Id == ProjectManagerId);
            var project = db.Projects.Find(id);
            pm.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

       
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
