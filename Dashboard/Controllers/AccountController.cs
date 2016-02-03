using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class AccountController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
	}
}