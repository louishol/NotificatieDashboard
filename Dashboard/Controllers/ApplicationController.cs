﻿using Dashboard.Models;
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
            ViewBag.customer = new SelectList(db.tblCustomers, "customerId", "contactPerson");
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
            ViewBag.customer = new SelectList(db.tblCustomers, "customerId", "contactPerson");

            return View();
        }
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