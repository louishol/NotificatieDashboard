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
        public ActionResult Create()
        {
            ViewBag.OS = new SelectList(db.tblOperatingSystems, "operatingSystemId", "name");
            ViewBag.phase = new SelectList(db.tblPhases, "phaseId", "name");
            ViewBag.customer = new SelectList(db.tblCustomers, "customerId", "companyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,repeatable,version,uniqueId,url,repeatVersion,tblOperatingSystems_operatingSystemId,tblPhases_phaseId,tblCustomers_customerId")] tblApplications tblapplications)
        {

            if (ModelState.IsValid)
            {
                db.tblApplications.Add(tblapplications);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.OS = new SelectList(db.tblOperatingSystems, "operatingSystemId", "name");
            ViewBag.phase = new SelectList(db.tblPhases, "phaseId", "name");    
            ViewBag.customer = new SelectList(db.tblCustomers, "customerId", "companyName");

            return View();
        }
        //
        // GET: /Application/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult addMessageToApplication(int appId, String message, int languageId)
        {
            var json = "";
            var application = db.tblApplications.Find(appId);
            if(application == null) {
                json = "{\"status\":\"500\", \"message\":\"Application not found\"}";
            } else {
                tblMessages msg = new tblMessages{message = message, tblApplications_applicationId = appId, tbLanguageCodes_languageId = languageId};
                application.tblMessages.Add(msg);
                db.SaveChanges();
                json = "{\"status\":\"200\", \"message\":\"Succes\"}";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int? id)
        {

            if (id != null && id > 0)
            {
                //Details of application
                tblApplications app = db.tblApplications.Find(id);
                //statistics
                ViewBag.appCount = 1;
                ViewBag.devCount = db.tblDevices.Where(d => d.tblApplications.applicationId == id).Count();
                ViewBag.crashCount = db.tblCrashReports.Where(c => c.tblDevices.tblApplications.applicationId == id).Count();
                //partial view
                tblMessages partial = new tblMessages();
                partial.tblApplications_applicationId= id.Value;
                ViewData["partial"] = partial;
                //Countries for the message dropdown in the partial view
                ViewBag.countries = new SelectList(db.tblLanguageCodes, "languageId", "name");

                return View(app);
            }
            return RedirectToAction("Index", "Home");
           
        }
	}
}