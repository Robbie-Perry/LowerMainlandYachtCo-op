using LmycWebSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace LmycWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;

        public RoleController()
        {
            context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        // GET: Role
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);

        }
        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Microsoft.AspNet.Identity.EntityFramework.IdentityRole Role)
        {
            roleManager.Create(Role);
            return RedirectToAction("Index");
        }

        // GET: Boats/Delete/5
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = roleManager.FindByName(name);

            if (role != null)
            {
                roleManager.Delete(role);
            }
            else
            {
                return new HttpNotFoundResult();
            }

            return RedirectToAction("Index");
        }

        // GET: Boats/Edit/5
        public ActionResult Edit(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = roleManager.FindByName(name);

            if (role != null)
            {
                List<ApplicationUser> listUsers = new List<ApplicationUser>();
                var users = roleManager.FindByName(name).Users.ToList();
                foreach (IdentityUserRole u in users)
                {
                    listUsers.Add(context.Users.Find(u.UserId));
                }
                
                ViewBag.Users = listUsers;
                return View(role);
            }
            else
            {
                return new HttpNotFoundResult("Role not found: " + name);
            }
            
        }

        public ActionResult Add(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = roleManager.FindByName(name);

            if (role != null)
            {
                List<ApplicationUser> listUsers = new List<ApplicationUser>();
                var roles = roleManager.Roles.ToArray();
                foreach (IdentityRole r in roles)
                {
                    foreach (IdentityUserRole iur in r.Users.ToArray())
                    {
                        if (!role.Users.Contains(iur))
                        {
                            listUsers.Add(context.Users.Find(iur.UserId));
                        }
                    }
                }

                ViewBag.Role = role;
                return View(listUsers);
            }
            else
            {
                return new HttpNotFoundResult("Unable to manage " + name);
            }
        }

        public ActionResult AddUser(string id, string role)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = context.Users.Find(id);

            if (user != null && role != null)
            {
                UserManager.AddToRole(id, role);
            }
            else
            {
                return new HttpNotFoundResult("Unable to find user with id:  " + id);
            }
            

            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id, string role)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            UserManager.RemoveFromRole(id, role);

            return RedirectToAction("Index");
        }

    }
}