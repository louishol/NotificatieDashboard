using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class ApplicationController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

        //
        // GET: /Application/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id != null && id > 0)
            {
                tblApplications app = db.tblApplications.Where(c => c.applicationId == id).First();
                ViewBag.appCount = db.tblApplications.Count();
                ViewBag.devCount = db.tblDevices.Count();
                ViewBag.crashCount = db.tblCrashReports.Count();
                return View(app);
            }
            return RedirectToAction("Index", "Home");
           
        }
	}
}