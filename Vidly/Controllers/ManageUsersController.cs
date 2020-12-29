using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Mvc.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [System.Web.Mvc.Authorize(Roles ="Admin")]
    public class ManageUsersController : Controller
    {

        private ApplicationDbContext _context;
        public UserManager<ApplicationUser> UserManager { get; private set; }
        

        public ManageUsersController()
        {
            _context = new ApplicationDbContext();

        }

        

        // GET: ManageUsers
        public ActionResult Register()
        {

                var listOfUsers = (from u in _context.Users
                               let query = (from ur in _context.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in _context.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UsersWithRoles(){ User = u, UserRoles = query.ToList<string>() })
                               .ToList()
                         ;
            var roles = _context.Roles.ToList();
            var UserAddShow = new UsersWithRoles() { Users = listOfUsers ,Roles = roles};

            

            return View(UserAddShow);


        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Register(UsersWithRoles model)

        {
            if (ModelState.IsValid)
            {

                //await UserManager.CreateAsync(user, model.RegisterUser.Password);

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
               

                //create default user
                var user = new ApplicationUser();
                user.UserName = model.RegisterUser.Email;
                user.Email = model.RegisterUser.Email;
                user.Phone = model.RegisterUser.Phone;
                var Password = model.RegisterUser.Password;
                user.DrivingLicense = model.RegisterUser.DrivingLicense;
                user.Phone = model.RegisterUser.Phone;
                var usrname = user.UserName;

                var newuser = userManager.Create(user, Password);
                user = _context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();


                var role = _context.Roles.Find(model.RoleId);
                var user1 =userManager.Find(user.UserName, Password);

                userManager.AddToRole(user1.Id, role.Name);
                _context.SaveChanges();

                


                return RedirectToAction("Index");
            }

            var listOfUsers = (from u in _context.Users
                               let query = (from ur in _context.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in _context.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UsersWithRoles() { User = u, UserRoles = query.ToList<string>() })
                               .ToList()
                         ;
            var roles = _context.Roles.ToList();
            var UserAddShow = new UsersWithRoles() { Users = listOfUsers, Roles = roles };
            // If we got this far, something failed, redisplay form
            return View(UserAddShow);

        }
        [System.Web.Mvc.HttpGet]
        public ActionResult AssignRole (string Id)
        {

            var UserinDb = _context.Users.Where(c => c.Id == Id).SingleOrDefault();
            if (UserinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            var user = new UsersWithRoles() { User = UserinDb };

            var role = _context.Roles.ToList();


            var roles = new UsersWithRoles() { Roles = role, User = UserinDb };


            return View(roles);




        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AssignRole(UsersWithRoles roles )
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            var role = _context.Roles.Find(roles.RoleId);
            var user2 = _context.Users.Find(roles.User.Id);

            var user1 = userManager.AddToRole(roles.User.Id, role.Name);

            var listOfRole = _context.Roles.ToList();

            var userRoles = new UsersWithRoles() { Roles = listOfRole, User = user2 };
            _context.SaveChanges();

            if (ModelState.IsValid)
            {
                //do something
                TempData["Success"] = "Success message text.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Error"] = "Error message text.";
            }
            return View("AssignRole", userRoles);


         }

        public ActionResult Index()
        {

            var listOfUsers = (from u in _context.Users
                               let query = (from ur in _context.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in _context.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UsersWithRoles() { User = u, UserRoles = query.ToList<string>() })
                           .ToList()
                     ;
            var roles = _context.Roles.ToList();
            var UserAddShow = new UsersWithRoles() { Users = listOfUsers, Roles = roles };



            return View(UserAddShow);


        }
        
        [System.Web.Mvc.HttpPost]
        public ActionResult Index(UsersWithRoles model)

        {
            if (ModelState.IsValid)
            {

                //await UserManager.CreateAsync(user, model.RegisterUser.Password);

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));


                //create default user
                var user = new ApplicationUser();
                user.UserName = model.RegisterUser.Email;
                user.Email = model.RegisterUser.Email;
                user.Phone = model.RegisterUser.Phone;
                var Password = model.RegisterUser.Password;
                user.DrivingLicense = model.RegisterUser.DrivingLicense;
                user.Phone = model.RegisterUser.Phone;
                var usrname = user.UserName;

                var newuser = userManager.Create(user, Password);
                user = _context.Users.Where(u => u.UserName.Equals(usrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();


                var role = _context.Roles.Find(model.RoleId);
                var user1 = userManager.Find(user.UserName, Password);

                userManager.AddToRole(user1.Id, role.Name);
                _context.SaveChanges();




                return RedirectToAction("Index");
            }

            var listOfUsers = (from u in _context.Users
                               let query = (from ur in _context.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in _context.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UsersWithRoles() { User = u, UserRoles = query.ToList<string>() })
                               .ToList()
                         ;
            var roles = _context.Roles.ToList();
            var UserAddShow = new UsersWithRoles() { Users = listOfUsers, Roles = roles };
            // If we got this far, something failed, redisplay form
            return View(UserAddShow);

        }
        [System.Web.Mvc.HttpGet]
        public ActionResult ResetPassword( string ID  )
        {
            var userinDB = _context.Users.Where(c => c.Id == ID).SingleOrDefault();
            if (userinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var user = new UsersWithRoles() { User = userinDB };

            return View("ResetPassword",user);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult>  ResetPassword ( UsersWithRoles user1 )
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            var user =  _context.Users.Where(x => x.Id == user1.User.Id).SingleOrDefaultAsync();
            if (user == null)

            {
                return RedirectToAction("ManageUsers");
            }
            await userManager.RemovePasswordAsync(user1.User.Id);

            await userManager.AddPasswordAsync(user1.User.Id, user1.ResetPassword.newPassword);

            return RedirectToAction("Index");
        }
        





        [System.Web.Mvc.HttpGet]
        public ActionResult DeleteRoles (string id)
        {
            var userinDB = _context.Users.Where(c => c.Id == id).SingleOrDefault();
            if (userinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            var user = new UsersWithRoles() { User = userinDB };

            var role = _context.Roles.ToList();


            var roles = new UsersWithRoles() { Roles = role, User = userinDB };


            return View(roles);

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult DeleteRoles( UsersWithRoles roles )
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            var role = _context.Roles.Find(roles.RoleId);
            var user2 = _context.Users.Find(roles.User.Id);

            var user1 = userManager.RemoveFromRole(roles.User.Id, role.Name);
            _context.SaveChanges();

            return
            RedirectToAction("Index");


        }
        public ActionResult Delete (string Id )
        {
            var UserinDb = _context.Users.SingleOrDefault(c => c.Id == Id);
            if (UserinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Users.Remove(UserinDb);
            _context.SaveChanges();

            return RedirectToAction ("Index");
        }

       
        private ActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }

}