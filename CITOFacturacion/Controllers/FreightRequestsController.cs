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
    public class FreightRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FreightRequests
        public async Task<ActionResult> Index()
        {
            return View(await db.FreightRequests.ToListAsync());
        }

        // GET: FreightRequests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreightRequest freightRequest = await db.FreightRequests.FindAsync(id);
            if (freightRequest == null)
            {
                return HttpNotFound();
            }
            return View(freightRequest);
        }

        // GET: FreightRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FreightRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FreightRequestId,Restrictions,ReqClientRate")] FreightRequest freightRequest)
        {
            if (ModelState.IsValid)
            {
                freightRequest.CreateDate = DateTime.UtcNow;
                db.FreightRequests.Add(freightRequest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(freightRequest);
        }

        // GET: FreightRequests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreightRequest freightRequest = await db.FreightRequests.FindAsync(id);
            if (freightRequest == null)
            {
                return HttpNotFound();
            }
            return View(freightRequest);
        }

        // POST: FreightRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FreightRequestId,Restrictions,ReqClientRate,CreateDate")] FreightRequest freightRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freightRequest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(freightRequest);
        }

        // GET: FreightRequests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreightRequest freightRequest = await db.FreightRequests.FindAsync(id);
            if (freightRequest == null)
            {
                return HttpNotFound();
            }
            return View(freightRequest);
        }

        // POST: FreightRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FreightRequest freightRequest = await db.FreightRequests.FindAsync(id);
            db.FreightRequests.Remove(freightRequest);
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
