using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SeaCargo.Models.DB;
using SeaCargo.Models.ViewModel;

namespace SeaCargo.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class UserAccountController : Controller
    {
        private SeaCargoDbContext db = new SeaCargoDbContext();

        // GET: tbl_accounts
        public ActionResult Index()
        {
            var getlst = db.tbl_accounts.Select(
              a => new UserProfileView
              {
                  AID = a.AID,
                  Username = a.Username,
                  Password = a.Password,
                  FName = a.FName,
                  LName = a.LName,
                  CDate = a.CDate,
                  Role = a.Role
              }).ToList();

            return View(getlst);
        }

        [HttpPost]
        public ActionResult Index(int CurrentPage, int LastPage)
        {
            var ulst = db.tbl_accounts.OrderBy(
               a => new UserProfileView
               {
                   AID = a.AID,
                   Username = a.Username,
                   Password = a.Password,
                   FName = a.FName,
                   LName = a.LName,
                   CDate = a.CDate,
                   Role = a.Role
               }).ToList();

            ViewBag.CurrentPage = CurrentPage + 1;
            ViewBag.LastPage = LastPage;
            return PartialView("_UsersList", ulst.OrderBy(x => x.FName).Skip((CurrentPage - 1) * 5).Take(5));
        }

        public JsonResult UsrList()
        {
            var getlst = db.tbl_accounts.OrderBy(
               a => new UserProfileView
               {
                   AID = a.AID,
                   Username = a.Username,
                   Password = a.Password,
                   FName = a.FName,
                   LName = a.LName,
                   CDate = a.CDate,
                   Role = a.Role
               }).ToList();


            //var getlst = db.tbl_accounts.Select(x=> new { AID = x.AID,Username=x.Username,Password=x.Password,FName=x.FName,LName=x.LName,Role=x.Role,CDate=x.CDate,Branch=x.Branch});
            //var getBra = db.Branches.Select(x => new { Id = x.Id, Name = x.Name, Desc = x.Desc });
            //ViewBag.BrList = new SelectList(getBra, "Id", "Name");

            return Json(getlst, JsonRequestBehavior.AllowGet);
        }

        //Delete users
        public JsonResult DelUsers(int id, int? pageNumber)
        {
            tbl_Account tbl_accounts = db.tbl_accounts.Find(id);
            db.tbl_accounts.Remove(tbl_accounts);
            db.SaveChanges();

            //list all users
            var showlst = db.tbl_accounts.OrderBy(
                a => new UserProfileView
                {
                    AID = a.AID,
                    Username = a.Username,
                    Password = a.Password,
                    FName = a.FName,
                    LName = a.LName,
                    CDate = a.CDate,
                    Role = a.Role
                }).ToList();

            return Json(showlst, JsonRequestBehavior.AllowGet);
        }

        // GET: tbl_accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Account tbl_accounts = db.tbl_accounts.Find(id);
            if (tbl_accounts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_accounts);
        }

        // GET: tbl_accounts/Create
        public ActionResult Create()
        {

            return View();
        }

        public JsonResult AddNewUser(string username, string password, string FName, string LName, string Role, int? pageNumber)
        {
            tbl_Account tbluser = new tbl_Account();
            tbluser.Username = username;
            tbluser.Password = password;
            tbluser.FName = FName;
            tbluser.LName = LName;
            tbluser.Role = Role;
            tbluser.CDate = DateTime.Now;
            db.tbl_accounts.Add(tbluser);
            db.SaveChanges();

            //joing two tables tbl_accounts and Branche, then using the result to fill the ViewModel UserProfileView
            var getlst = db.tbl_accounts.OrderBy(
               a => new UserProfileView
               {
                   AID = a.AID,
                   Username = a.Username,
                   Password = a.Password,
                   FName = a.FName,
                   LName = a.LName,
                   CDate = a.CDate,
                   Role = a.Role
               }).ToList();

            // var getlst = db.tbl_accounts.Select(x => new { AID = x.AID, Username = x.Username, Password = x.Password, FName = x.FName, LName = x.LName, Role = x.Role, CDate = x.CDate, Branch = x.Branch });
            return Json(getlst, JsonRequestBehavior.AllowGet);
        }

        //Find users

        public JsonResult FindUsers(int id)
        {
            //joing two tables tbl_accounts and Branche, then using the result to fill the ViewModel UserProfileView
            var getlst = db.tbl_accounts.Where(x => x.AID.Equals(id)).Select(
               a => new UserProfileView
               {
                   AID = a.AID,
                   Username = a.Username,
                   Password = a.Password,
                   FName = a.FName,
                   LName = a.LName,
                   CDate = a.CDate,
                   Role = a.Role
               }).ToList();

            // var getlst = db.tbl_accounts.Select(x => new { AID = x.AID, Username = x.Username, Password = x.Password, FName = x.FName, LName = x.LName, Role = x.Role, CDate = x.CDate, Branch = x.Branch });
            return Json(getlst, JsonRequestBehavior.AllowGet);
        }

        // Edit UsersAccounts
        public JsonResult EditUsers(int id, string username, string password, string FName, string LName, string Role)
        {
            tbl_Account tbluser = db.tbl_accounts.Where(x => x.AID.Equals(id)).FirstOrDefault();
            tbluser.Username = username;
            tbluser.Password = password;
            tbluser.FName = FName;
            tbluser.LName = LName;
            tbluser.Role = Role;
            tbluser.CDate = DateTime.Now;

            db.SaveChanges();

            //joing two tables tbl_accounts and Branche, then using the result to fill the ViewModel UserProfileView
            var getlst = db.tbl_accounts.OrderBy(
               a => new UserProfileView
               {
                   AID = a.AID,
                   Username = a.Username,
                   Password = a.Password,
                   FName = a.FName,
                   LName = a.LName,
                   CDate = a.CDate,
                   Role = a.Role
               }).ToList();

            // var getlst = db.tbl_accounts.Select(x => new { AID = x.AID, Username = x.Username, Password = x.Password, FName = x.FName, LName = x.LName, Role = x.Role, CDate = x.CDate, Branch = x.Branch });
            return Json(getlst, JsonRequestBehavior.AllowGet);
        }

        // GET: tbl_accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Account tbl_accounts = db.tbl_accounts.Find(id);
            if (tbl_accounts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_accounts);
        }

        // POST: tbl_accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AID,Username,Password,FName,LName,CDate,Branch")] tbl_Account tbl_accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_accounts);
        }

        // GET: tbl_accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Account tbl_accounts = db.tbl_accounts.Find(id);
            if (tbl_accounts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_accounts);
        }

        // POST: tbl_accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Account tbl_accounts = db.tbl_accounts.Find(id);
            db.tbl_accounts.Remove(tbl_accounts);
            db.SaveChanges();
            return RedirectToAction("Index");
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
