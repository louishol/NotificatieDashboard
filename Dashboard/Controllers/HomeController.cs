using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

       // [Authorize]
        public ActionResult Index()
        {
            ViewBag.appCount = db.tblApplications.Count();
            ViewBag.devCount = db.tblDevices.Count();
            ViewBag.crashCount = db.tblCrashReports.Count();

            ViewBag.applications = db.tblApplications.ToList();

            return View();
        }
    }
}