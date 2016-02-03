using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dashboard.Controllers
{
    public class AccountController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

        //
        // GET: /Account/
        public ActionResult Login(String returnurl = "")
        {

            ViewBag.ReturnUrl = returnurl;
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {

            if (db.tblUsers.Where(c => c.loginName == model.UserName && c.password == model.Password).FirstOrDefault() != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
            }
       
            return View();
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}