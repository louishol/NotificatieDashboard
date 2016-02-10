using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;
using Lib.Models;

namespace Dashboard.Controllers
{
    public class CustomerController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();


        public ActionResult Details(int? id)
        {

            //Customer ophalen
            var customer = Lib.DAL.Customers.GetDetails(id);
            if (customer == null) throw new HttpException(404, "Customer not found");
            //Template statistieken ophalen
            var progStats = Lib.DAL.Applications.GetProgramStatistics();
            //vullen van de statistieken van de template layout.
            ViewBag.devCount = progStats.devicesCount == null ? 0 : (int)progStats.devicesCount;
            ViewBag.appCount = progStats.applicatiesCount == null ? 0 : (int)progStats.applicatiesCount;
            ViewBag.crashCount = progStats.crashCount == null ? 0 : (int)progStats.crashCount;
            return View(customer);
        
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View(new Customer());
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "contactPerson,companyName,email,address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Lib.DAL.Customers.Create(customer);
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }

        // GET: /Customer/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblCustomers tblcustomers = db.tblCustomers.Find(id);
        //    if (tblcustomers == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblcustomers);
        //}

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="customerId,contactPerson,companyName,email,address,dateCreated")] tblCustomers tblcustomers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tblcustomers).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tblcustomers);
        //}

        //public ActionResult Delete(int id = 0)
        //{
        //    tblCustomers customer = db.tblCustomers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        //
        // POST: /Movies/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = Lib.DAL.Customers.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
