using System;
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
    public class ddwdwdController : Controller
    {
        private AppVersionCheckEntities db = new AppVersionCheckEntities();

        // GET: /ddwdwd/
        public ActionResult Index()
        {
            var tblapplications = db.tblApplications.Include(t => t.tblOperatingSystems).Include(t => t.tblCustomers).Include(t => t.tblPhases);
            return View(tblapplications.ToList());
        }

        // GET: /ddwdwd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApplications tblapplications = db.tblApplications.Find(id);
            if (tblapplications == null)
            {
                return HttpNotFound();
            }
            return View(tblapplications);
        }

        // GET: /ddwdwd/Create
        public ActionResult Create()
        {
            ViewBag.tblOperatingSystems_operatingSystemId = new SelectList(db.tblOperatingSystems, "operatingSystemId", "name");
            ViewBag.tblCustomers_customerId = new SelectList(db.tblCustomers, "customerId", "firstName");
            ViewBag.tblPhases_phaseId = new SelectList(db.tblPhases, "phaseId", "name");
            return View();
        }

        // POST: /ddwdwd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="applicationId,name,repeatable,version,uniqueId,url,repeatVersion,tblOperatingSystems_operatingSystemId,tblPhases_phaseId,tblCustomers_customerId")] tblApplications tblapplications)
        {
            if (ModelState.IsValid)
            {
                db.tblApplications.Add(tblapplications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tblOperatingSystems_operatingSystemId = new SelectList(db.tblOperatingSystems, "operatingSystemId", "name", tblapplications.tblOperatingSystems_operatingSystemId);
            ViewBag.tblCustomers_customerId = new SelectList(db.tblCustomers, "customerId", "firstName", tblapplications.tblCustomers_customerId);
            ViewBag.tblPhases_phaseId = new SelectList(db.tblPhases, "phaseId", "name", tblapplications.tblPhases_phaseId);
            return View(tblapplications);
        }

        // GET: /ddwdwd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApplications tblapplications = db.tblApplications.Find(id);
            if (tblapplications == null)
            {
                return HttpNotFound();
            }
            ViewBag.tblOperatingSystems_operatingSystemId = new SelectList(db.tblOperatingSystems, "operatingSystemId", "name", tblapplications.tblOperatingSystems_operatingSystemId);
            ViewBag.tblCustomers_customerId = new SelectList(db.tblCustomers, "customerId", "firstName", tblapplications.tblCustomers_customerId);
            ViewBag.tblPhases_phaseId = new SelectList(db.tblPhases, "phaseId", "name", tblapplications.tblPhases_phaseId);
            return View(tblapplications);
        }

        // POST: /ddwdwd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="applicationId,name,repeatable,version,uniqueId,url,repeatVersion,tblOperatingSystems_operatingSystemId,tblPhases_phaseId,tblCustomers_customerId")] tblApplications tblapplications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblapplications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tblOperatingSystems_operatingSystemId = new SelectList(db.tblOperatingSystems, "operatingSystemId", "name", tblapplications.tblOperatingSystems_operatingSystemId);
            ViewBag.tblCustomers_customerId = new SelectList(db.tblCustomers, "customerId", "firstName", tblapplications.tblCustomers_customerId);
            ViewBag.tblPhases_phaseId = new SelectList(db.tblPhases, "phaseId", "name", tblapplications.tblPhases_phaseId);
            return View(tblapplications);
        }

        // GET: /ddwdwd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblApplications tblapplications = db.tblApplications.Find(id);
            if (tblapplications == null)
            {
                return HttpNotFound();
            }
            return View(tblapplications);
        }

        // POST: /ddwdwd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblApplications tblapplications = db.tblApplications.Find(id);
            db.tblApplications.Remove(tblapplications);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
