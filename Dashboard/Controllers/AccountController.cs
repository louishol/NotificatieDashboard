using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public ActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {

            string hPassword = sha256(model.Password);

            if (db.tblUsers.Where(c => c.loginName == model.UserName && c.password == hPassword).FirstOrDefault() != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return Redirect(ReturnUrl);
            }
       
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
      
        static string sha256(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
	}
}