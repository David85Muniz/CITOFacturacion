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
    public class SubDivisionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubDivisions
        public async Task<ActionResult> Index()
        {
            return View(await db.SubDivisions.ToListAsync());
        }

        // GET: SubDivisions/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDivision subDivision = await db.SubDivisions.FindAsync(id);
            if (subDivision == null)
            {
                return HttpNotFound();
            }
            return View(subDivision);
        }

        // GET: SubDivisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubDivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubDivisionId,ShortName,LongName,AKA,Abbreviation,Code2Char,Code3Char")] SubDivision subDivision)
        {
            if (ModelState.IsValid)
            {
                subDivision.SubDivisionId = Guid.NewGuid();
                db.SubDivisions.Add(subDivision);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subDivision);
        }

        // GET: SubDivisions/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDivision subDivision = await db.SubDivisions.FindAsync(id);
            if (subDivision == null)
            {
                return HttpNotFound();
            }
            return View(subDivision);
        }

        // POST: SubDivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubDivisionId,ShortName,LongName,AKA,Abbreviation,Code2Char,Code3Char")] SubDivision subDivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subDivision).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subDivision);
        }

        // GET: SubDivisions/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDivision subDivision = await db.SubDivisions.FindAsync(id);
            if (subDivision == null)
            {
                return HttpNotFound();
            }
            return View(subDivision);
        }

        // POST: SubDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SubDivision subDivision = await db.SubDivisions.FindAsync(id);
            db.SubDivisions.Remove(subDivision);
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
