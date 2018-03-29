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
    public class SchoolLevelsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: SchoolLevels
        public async Task<ActionResult> Index()
        {
            return View(await db.SchoolLevels.ToListAsync());
        }

        // GET: SchoolLevels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolLevel schoolLevel = await db.SchoolLevels.FindAsync(id);
            if (schoolLevel == null)
            {
                return HttpNotFound();
            }
            return View(schoolLevel);
        }

        // GET: SchoolLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SchoolLevelId,Name")] SchoolLevel schoolLevel)
        {
            if (ModelState.IsValid)
            {
                db.SchoolLevels.Add(schoolLevel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(schoolLevel);
        }

        // GET: SchoolLevels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolLevel schoolLevel = await db.SchoolLevels.FindAsync(id);
            if (schoolLevel == null)
            {
                return HttpNotFound();
            }
            return View(schoolLevel);
        }

        // POST: SchoolLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SchoolLevelId,Name")] SchoolLevel schoolLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolLevel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(schoolLevel);
        }

        // GET: SchoolLevels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolLevel schoolLevel = await db.SchoolLevels.FindAsync(id);
            if (schoolLevel == null)
            {
                return HttpNotFound();
            }
            return View(schoolLevel);
        }

        // POST: SchoolLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SchoolLevel schoolLevel = await db.SchoolLevels.FindAsync(id);
            db.SchoolLevels.Remove(schoolLevel);
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
