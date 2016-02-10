using Dashboard.Models;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Lib.Models;

namespace Dashboard.Controllers
{
    public class ApplicationController : Controller
    {
        //private AppVersionCheckEntities db = new AppVersionCheckEntities();
        [HttpGet]
        public ActionResult Create()
        {
            //Template statistieken ophalen
            var progStats = Lib.DAL.Applications.GetProgramStatistics();
            //vullen van de statistieken van de template layout.
            ViewBag.devCount = progStats.devicesCount == null ? 0 : (int)progStats.devicesCount;
            ViewBag.appCount = progStats.applicatiesCount == null ? 0 : (int)progStats.applicatiesCount;
            ViewBag.crashCount = progStats.crashCount == null ? 0 : (int)progStats.crashCount;

            ApplicationCreateViewModel VM = new ApplicationCreateViewModel
            {
                Phases = Lib.DAL.Phases.Get(),
                Customers = Lib.DAL.Customers.Get(),
                OperatingSystems = Lib.DAL.OperatingSystems.Get()
            };
            return View(VM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,repeatable,version,uniqueId,url,repeatVersion,tblOperatingSystems_operatingSystemId,tblPhases_phaseId,tblCustomers_customerId")] ApplicationCreateViewModel vmApplication)
        {
            if (ModelState.IsValid)
            {
                var application = Mapper.Map<ApplicationCreateViewModel, Application>(vmApplication);
                Lib.DAL.Applications.Create(application);
                return RedirectToAction("Index", "Home");
            }
            //Template statistieken ophalen
            var progStats = Lib.DAL.Applications.GetProgramStatistics();
            //vullen van de statistieken van de template layout.
            ViewBag.devCount = progStats.devicesCount == null ? 0 : (int)progStats.devicesCount;
            ViewBag.appCount = progStats.applicatiesCount == null ? 0 : (int)progStats.applicatiesCount;
            ViewBag.crashCount = progStats.crashCount == null ? 0 : (int)progStats.crashCount;

            return View(vmApplication);
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

        public JsonResult GetNewSetOfApplications(int pageNr)
        {
            var application = Lib.DAL.Applications.Get(10, pageNr);
            return Json(application, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(int id = 0)
        {
            var application = Lib.DAL.Applications.GetDetails(id);
            if (application == null) throw new HttpException(404, "Application not found");
            ViewData["partial"] = new MessageViewModel { tblApplications_applicationId = id };
            ViewBag.countries = new SelectList(Lib.DAL.LanguageCodes.Get(), "languageId", "name");
            return View(application);
        }
        public ActionResult Delete(int id)
        {
            var application = Lib.DAL.Applications.Delete(id);

            return RedirectToAction("Index", "Home");
        }
	}
}