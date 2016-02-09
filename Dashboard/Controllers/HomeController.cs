using Dashboard.Models;
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

            var progStats = Lib.DAL.Applications.GetProgramStatistics();
            //vullen van de statistieken van de template layout.
            //Dit moet in de viewbag
            ViewBag.devCount = progStats.devicesCount == null ? 0 : (int)progStats.devicesCount;
            ViewBag.appCount = progStats.applicatiesCount == null ? 0 : (int)progStats.applicatiesCount;
            ViewBag.crashCount = progStats.crashCount == null ? 0 : (int)progStats.crashCount;
          
            HomeViewModel Information = new HomeViewModel
            {
                Applications = Lib.DAL.Applications.Get(),
                CrashReports = Lib.DAL.CrashReports.Get(),
                Devices = Lib.DAL.Devices.GetDevicesInRecentDate(7),
                Customers = Lib.DAL.Customers.Get(),
                Popular = Lib.DAL.Applications.GetPopularApps(10),
                OSStatistics = Lib.DAL.OperatingSystems.GetStatistics()
            };

            return View(Information);
        }
    }
}