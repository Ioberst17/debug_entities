using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AthleticDebug.DAL;

namespace AthleticDebug.Controllers
{
    //[Authorize]
    public class AthletesController : Controller
    {
        private ClassProjectContext db = new ClassProjectContext();

        public ActionResult Index() => View(db.Athletes.Include(a => a.Results));


        // GET: Athletes
        [HttpPost]
        public ActionResult Index(String SearchName)
        {
            var res = db.Athletes.Where(p => p.FName.Contains(SearchName)).ToList();
            return View(res);
        }

        // GET: Athletes/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.AthleteResult = id;
            Result result = db.Results.Find(id);
            var athleteResult = db.Results.Where(i => i.AthleteID == id);
            /*if (result == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            //Athlete athlete = db.Athletes.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            Athlete temp = db.Athletes.Find(id);
            string pic = temp.Picture;
            ViewBag.Picture = pic;
            return View(athleteResult);
        }



        // GET: Athletes/Create
        public ActionResult Create()
        {
            ViewBag.CoachID = new SelectList(db.Coaches, "ID", "Name");
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FName,LName,Gender,Picture,CoachID,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachID = new SelectList(db.Coaches, "ID", "Name", athlete.CoachID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", athlete.TeamID);
            return View(athlete);
        }

        // GET: Athletes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachID = new SelectList(db.Coaches, "ID", "Name", athlete.CoachID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", athlete.TeamID);
            return View(athlete);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FName,LName,Gender,Picture,CoachID,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(athlete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachID = new SelectList(db.Coaches, "ID", "Name", athlete.CoachID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", athlete.TeamID);
            return View(athlete);
        }

        // GET: Athletes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }
            return View(athlete);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Athlete athlete = db.Athletes.Find(id);
            db.Athletes.Remove(athlete);
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
