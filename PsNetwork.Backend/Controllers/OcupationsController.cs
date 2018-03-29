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
    public class OcupationsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Ocupations
        public async Task<ActionResult> Index()
        {
            return View(await db.Ocupations.ToListAsync());
        }

        // GET: Ocupations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocupation ocupation = await db.Ocupations.FindAsync(id);
            if (ocupation == null)
            {
                return HttpNotFound();
            }
            return View(ocupation);
        }

        // GET: Ocupations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ocupations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OcupationId,Name")] Ocupation ocupation)
        {
            if (ModelState.IsValid)
            {
                db.Ocupations.Add(ocupation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ocupation);
        }

        // GET: Ocupations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocupation ocupation = await db.Ocupations.FindAsync(id);
            if (ocupation == null)
            {
                return HttpNotFound();
            }
            return View(ocupation);
        }

        // POST: Ocupations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OcupationId,Name")] Ocupation ocupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocupation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ocupation);
        }

        // GET: Ocupations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocupation ocupation = await db.Ocupations.FindAsync(id);
            if (ocupation == null)
            {
                return HttpNotFound();
            }
            return View(ocupation);
        }

        // POST: Ocupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ocupation ocupation = await db.Ocupations.FindAsync(id);
            db.Ocupations.Remove(ocupation);
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
