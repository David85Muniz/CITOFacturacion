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
    public class SubDivision2ndLvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubDivision2ndLv
        public async Task<ActionResult> Index()
        {
            return View(await db.SubDivision2ndLv.ToListAsync());
        }

        // GET: SubDivision2ndLv/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDivision2ndLv subDivision2ndLv = await db.SubDivision2ndLv.FindAsync(id);
            if (subDivision2ndLv == null)
            {
                return HttpNotFound();
            }
            return View(subDivision2ndLv);
        }

        // GET: SubDivision2ndLv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubDivision2ndLv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubDivision2ndLvId,ShortName,LongName,Abbreviation,OriginCityId,DestinationCityId")] SubDivision2ndLv subDivision2ndLv)
        {
            if (ModelState.IsValid)
            {
                subDivision2ndLv.SubDivision2ndLvId = Guid.NewGuid();
                db.SubDivision2ndLv.Add(subDivision2ndLv);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subDivision2ndLv);
        }

        // GET: SubDivision2ndLv/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDivision2ndLv subDivision2ndLv = await db.SubDivision2ndLv.FindAsync(id);
            if (subDivision2ndLv == null)
            {
                return HttpNotFound();
            }
            return View(subDivision2ndLv);
        }

        // POST: SubDivision2ndLv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubDivision2ndLvId,ShortName,LongName,Abbreviation,OriginCityId,DestinationCityId")] SubDivision2ndLv subDivision2ndLv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subDivision2ndLv).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subDivision2ndLv);
        }

        // GET: SubDivision2ndLv/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDivision2ndLv subDivision2ndLv = await db.SubDivision2ndLv.FindAsync(id);
            if (subDivision2ndLv == null)
            {
                return HttpNotFound();
            }
            return View(subDivision2ndLv);
        }

        // POST: SubDivision2ndLv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SubDivision2ndLv subDivision2ndLv = await db.SubDivision2ndLv.FindAsync(id);
            db.SubDivision2ndLv.Remove(subDivision2ndLv);
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
