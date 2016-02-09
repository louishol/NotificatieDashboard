using Dashboard.Models;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

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
        public JsonResult addMessageToApplication(MessageViewModel VMMessage)
        {
            var application = Lib.DAL.Applications.AddMessage(VMMessage);
            if (application == null)
            {
                return Json(new { status = "500", message = "Application not found" });
            }
            return Json(new { status = "200", message = "Succes" });
          
        }
        public ActionResult Details(int id = 0)
        {
            var application = Lib.DAL.Applications.GetDetails(id);
            if (application == null) throw new HttpException(404, "Application not found");
            ViewData["partial"] = new MessageViewModel { tblApplications_applicationId = id };
            ViewBag.countries = new SelectList(db.tblLanguageCodes, "languageId", "name");
            return View(application);
        }
	}
}