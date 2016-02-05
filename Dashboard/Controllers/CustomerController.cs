﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class CustomerController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

        // GET: /Customer/
        public ActionResult Index()
        {
            return View(db.tblCustomers.ToList());
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null && id > 0)
            {
                tblCustomers tblcustomers = db.tblCustomers.Find(id);
                ViewBag.appCount = db.tblApplications.Where(c => c.tblCustomers.customerId == id).Count();
                ViewBag.devCount = db.tblDevices.Where(d => d.tblApplications.tblCustomers.customerId == id).Count();
                ViewBag.crashCount = db.tblCrashReports.Where(c => c.tblDevices.tblApplications.tblCustomers.customerId == id).Count();
                if (tblcustomers == null)
                {
                    return HttpNotFound();
                }
                return View(tblcustomers);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="contactPerson,companyName,email,address")] tblCustomers tblcustomers)
        {
            if (ModelState.IsValid)
            {
                tblcustomers.dateCreated = DateTime.Now;
                db.tblCustomers.Add(tblcustomers);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomers tblcustomers = db.tblCustomers.Find(id);
            if (tblcustomers == null)
            {
                return HttpNotFound();
            }
            return View(tblcustomers);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="customerId,contactPerson,companyName,email,address,dateCreated")] tblCustomers tblcustomers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcustomers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcustomers);
        }


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
        public ActionResult Delete(int? id)
        {
            tblCustomers customer = db.tblCustomers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            db.tblCustomers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

       
    }
}
