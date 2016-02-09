﻿using Dashboard.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

       // [Authorize]
        public ActionResult Index()
        {


            HomeInformation Information = new HomeInformation
            {
                DeviceCount = Lib.DAL.Applications.GetCount()
                    
            };

            ViewBag.appCount = Lib.DAL.Applications.GetCount();
            ViewBag.devCount = db.tblDevices.Count();
            ViewBag.crashCount = db.tblCrashReports.Count();

            ViewBag.applications = db.tblApplications.ToList();
            ViewBag.customers = db.tblCustomers.ToList();
            var dateweekago = DateTime.Now.AddDays(-7);
            ViewBag.devices = db.tblDevices.Where(d => d.insertDate > dateweekago).ToList();

            string query = "Select applicationId, name, COUNT(*) as devices from tblApplications join tblDevices on tblDevices.tblApplications_applicationId = tblApplications.applicationId group by name, applicationId order by devices DESC";
            ViewBag.popularApplications = db.Database.SqlQuery<PopularApp>(query).ToList();

            query = "select tblOperatingSystems.name, COUNT(*) as counter from tblApplications JOIN tblOperatingSystems on tblApplications.tblOperatingSystems_operatingSystemId = tblOperatingSystems.operatingSystemId group by tblOperatingSystems.name";
            //var dic = db.Database.SqlQuery<PercentageApp>(query).ToList();
            ViewBag.osPercentage = db.Database.SqlQuery<PercentageApp>(query).ToList();
            return View();
        }
    }
}