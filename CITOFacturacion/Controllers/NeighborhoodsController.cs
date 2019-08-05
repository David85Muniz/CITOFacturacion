using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CITOFacturacion.Models;
using CITOFacturacion.Models.Entities;

namespace CITOFacturacion
{
    public class NeighborhoodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Neighborhoods
        public async Task<ActionResult> Index()
        {
            return View(await db.Neighborhoods.ToListAsync());
        }

        // GET: Neighborhoods/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = await db.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NeighborhoodId,Name,PostalCode")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                neighborhood.NeighborhoodId = Guid.NewGuid();
                db.Neighborhoods.Add(neighborhood);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = await db.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NeighborhoodId,Name,PostalCode")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neighborhood).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = await db.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Neighborhood neighborhood = await db.Neighborhoods.FindAsync(id);
            db.Neighborhoods.Remove(neighborhood);
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
