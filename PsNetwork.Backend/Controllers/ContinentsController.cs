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
    public class ContinentsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Continents
        public async Task<ActionResult> Index()
        {
            return View(await db.Continents.ToListAsync());
        }

        // GET: Continents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Continent continent = await db.Continents.FindAsync(id);
            if (continent == null)
            {
                return HttpNotFound();
            }
            return View(continent);
        }

        // GET: Continents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Continents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ContinentId,Code,Name,Demonym")] Continent continent)
        {
            if (ModelState.IsValid)
            {
                db.Continents.Add(continent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(continent);
        }

        // GET: Continents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Continent continent = await db.Continents.FindAsync(id);
            if (continent == null)
            {
                return HttpNotFound();
            }
            return View(continent);
        }

        // POST: Continents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContinentId,Code,Name,Demonym")] Continent continent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(continent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(continent);
        }

        // GET: Continents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Continent continent = await db.Continents.FindAsync(id);
            if (continent == null)
            {
                return HttpNotFound();
            }
            return View(continent);
        }

        // POST: Continents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Continent continent = await db.Continents.FindAsync(id);
            db.Continents.Remove(continent);
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
