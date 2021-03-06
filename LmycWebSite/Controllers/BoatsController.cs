﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using LmycDataLib.Models;
using LmycWebSite.Models;
using System.Linq;

namespace LmycWebSite.Controllers
{
    [Authorize]
    public class BoatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Boats
        public async Task<ActionResult> Index()
        {
            return View(await db.Boats.ToListAsync());
        }

        // GET: Boats/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = await db.Boats.FindAsync(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        // GET: Boats/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "BoatId,BoatName,Picture,LengthInFeet,Make,Year,RecordCreationDate,UserId")] Boat boat)
        {
            boat.RecordCreationDate = DateTime.Now;
            boat.ApplicationUser = db.Users.FirstOrDefault(
                u => u.UserName == User.Identity.Name
            );
            db.Boats.Add(boat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Boats/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = await db.Boats.FindAsync(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "BoatId,BoatName,Picture,LengthInFeet,Make,Year,RecordCreationDate,UserId")] Boat boat)
        {
            boat.UserId = db.Users.FirstOrDefault(
               u => u.UserName == User.Identity.Name
           ).Id;

            db.Entry(boat).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Boats/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boat boat = await db.Boats.FindAsync(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        // POST: Boats/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Boat boat = await db.Boats.FindAsync(id);
            db.Boats.Remove(boat);
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
