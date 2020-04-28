using DDToolKit.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DDToolKit.Controllers
{
    public class MapsController : Controller
    {
        private gameModel db = new gameModel();

        // GET: Maps
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();

            return View(db.Maps.ToList().Where(s => s.OwnerID.Contains(id)));
        }


        public ActionResult Manage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string Uid = User.Identity.GetUserId();
            var temp = db.Maps.ToList().Where(s => s.OwnerID.Contains(Uid));
            ViewBag.gameid = id;
            return View(temp.Where(s => s.GameID.ToString().Contains(id.ToString())));
        }
        // GET: Maps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // GET: Maps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [Bind(Include = "ID,Name,MapWidth,MapHeight")] Map map)
        {
            map.OwnerID = User.Identity.GetUserId();
            map.GameID = id;
            map.MapLand = "";
            map.MapObjects = "";
            if (ModelState.IsValid)
            {
                db.Maps.Add(map);
                db.SaveChanges();
                return RedirectToAction("Manage/" + id.ToString());
            }
            return View(map);
        }

        // GET: Maps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            ViewBag.test = map.MapLand;
            return View(map);
        }

        // POST: Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OwnerID,GameID,Name,MapWidth,MapHeight,MapLand,MapObjects")] Map map)
        {
            map.OwnerID = User.Identity.GetUserId();
            map.GameID = map.GameID;
            //map.MapLand = "0000";
            //map.MapObjects = "0000";
            if (ModelState.IsValid)
            {
                db.Entry(map).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage/" + map.GameID.ToString());
            }
            return View(map);
        }

        // GET: Maps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // POST: Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Map map = db.Maps.Find(id);
            db.Maps.Remove(map);
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
