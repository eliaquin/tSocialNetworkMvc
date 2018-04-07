using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PsNetwork.Domain;
using PsNetwork.Frontend.Models;
using Microsoft.AspNet.Identity;
using PsNetwork.Frontend.Helpers;

namespace PsNetwork.Frontend.Controllers
{
    public class UsersController : Controller
    {
        private DataContextLocal db = new DataContextLocal();



        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set {
                _signInManager = value;
            }
        }


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }
        private ApplicationSignInManager _signInManager;

        public ActionResult Create()
        {
            var userProfile = new Profile { StatusId = 1, UserTypeId = 1,Email="",Password="" };
            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Profile profile)
        {
            if (ModelState.IsValid)
            {

                var newuser = new ApplicationUser { UserName = profile.Email, Email = profile.Email };
                var result = await UserManager.CreateAsync(newuser, profile.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(newuser, isPersistent: false, rememberBrowser: false);

                    // return RedirectToAction("Index", "Home");
                }
                AddErrors(result);

                var pic = string.Empty;
                const string folder = "~/Content/UsersProfile";

                if (profile.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(profile.ImageFile, folder, "");
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var user = new User
                {
                    UserId = profile.UserId,
                    UserTypeId = profile.UserTypeId,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Email = profile.Email,
                    StatusId = profile.StatusId
                };


                user.Picture = pic;

                db.Users.Add(user);
                await db.SaveChangesAsync();
                //  return RedirectToAction($"Details/{user.UserId}");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name", profile.StatusId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name", profile.UserTypeId);
            return View(profile);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name", user.StatusId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name", user.UserTypeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Name", user.StatusId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name", user.UserTypeId);
            return View(user);
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
