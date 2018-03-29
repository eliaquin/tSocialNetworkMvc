using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsNetwork.Backend.Models;
using PsNetwork.Domain;

namespace PsNetwork.Backend.Controllers
{
    public class MaritalSituationsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: MaritalSituations
        public async Task<ActionResult> Index()
        {
            return View(await db.MaritalSituations.ToListAsync());
        }

        // GET: MaritalSituations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalSituation maritalSituation = await db.MaritalSituations.FindAsync(id);
            if (maritalSituation == null)
            {
                return HttpNotFound();
            }
            return View(maritalSituation);
        }

        // GET: MaritalSituations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalSituations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaritalSituationId,Name")] MaritalSituation maritalSituation)
        {
            if (ModelState.IsValid)
            {
                db.MaritalSituations.Add(maritalSituation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maritalSituation);
        }

        // GET: MaritalSituations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalSituation maritalSituation = await db.MaritalSituations.FindAsync(id);
            if (maritalSituation == null)
            {
                return HttpNotFound();
            }
            return View(maritalSituation);
        }

        // POST: MaritalSituations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaritalSituationId,Name")] MaritalSituation maritalSituation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maritalSituation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maritalSituation);
        }

        // GET: MaritalSituations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaritalSituation maritalSituation = await db.MaritalSituations.FindAsync(id);
            if (maritalSituation == null)
            {
                return HttpNotFound();
            }
            return View(maritalSituation);
        }

        // POST: MaritalSituations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MaritalSituation maritalSituation = await db.MaritalSituations.FindAsync(id);
            db.MaritalSituations.Remove(maritalSituation);
            await db.SaveChangesAsync();
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
