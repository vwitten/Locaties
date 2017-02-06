using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Locaties.Models;
using Newtonsoft.Json;

namespace Locaties.Controllers
{
    public class LocatiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locaties
        public ActionResult Index()
        {
            string json = System.IO.File.ReadAllText(Server.MapPath("~/JSON/locaties.json"));
            var LocatieLijst = JsonConvert.DeserializeObject<List<Locatie>>(json);
            return View(LocatieLijst/*db.Locaties.ToList()*/);
        }

        // GET: Locaties/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.Locaties.Find(id);
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // GET: Locaties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocatieID,Longitude,Street,Latitude,City,ZipCode,StoreName")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                locatie.LocatieID = Guid.NewGuid();
                db.Locaties.Add(locatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locatie);
        }

        // GET: Locaties/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.Locaties.Find(id);
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // POST: Locaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocatieID,Longitude,Street,Latitude,City,ZipCode,StoreName")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locatie);
        }

        // GET: Locaties/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.Locaties.Find(id);
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // POST: Locaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Locatie locatie = db.Locaties.Find(id);
            db.Locaties.Remove(locatie);
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
