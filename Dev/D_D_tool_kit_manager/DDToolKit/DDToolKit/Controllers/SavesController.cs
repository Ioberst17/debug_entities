using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDToolKit.Models;
using Microsoft.AspNet.Identity;

namespace DDToolKit.Controllers
{
    public class SavesController : Controller
    {
        private gameModel db = new gameModel();

        // GET: Saves
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            return View(db.Saves.ToList().Where(s => s.OwnerID.Contains(id)));
        }


        // GET: Saves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Save save = db.Saves.Find(id);
            if (save == null)
            {
                return HttpNotFound();
            }
            return View(save);
        }

        // GET: Saves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,OwnerID,Monsters")] Save save)
        {

            save.OwnerID = User.Identity.GetUserId();
            save.Monsters = "Zombie";
            if (ModelState.IsValid)
            {
                db.Saves.Add(save);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(save);
        }

        // GET: Saves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Save save = db.Saves.Find(id);
            if (save == null)
            {
                return HttpNotFound();
            }
            return View(save);
        }

        // POST: Saves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,OwnerID,Monsters")] Save save)
        {
            if (ModelState.IsValid)
            {
                db.Entry(save).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(save);
        }

        // GET: Saves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Save save = db.Saves.Find(id);
            if (save == null)
            {
                return HttpNotFound();
            }
            return View(save);
        }

        // POST: Saves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Save save = db.Saves.Find(id);
            db.Saves.Remove(save);
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
        public ActionResult Game(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var test = db.Saves.ToList().Where(s => s.ID == id);
            var test2 = db.Saves.Where(s => s.ID == id);
            //var t3 = test2.monsters;
            ViewBag.Mons = test2;
            return View(db.Players.ToList().Where(s => s.GameID == id));
        }
        public ActionResult CreatePlayer()
        {
            return View();
        }
        // POST: Saves/CreatePlayer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlayer(int id, [Bind(Include = "ID,OwnerID,GameID,Name,Size,Type,Aligment,ArmorClass,HitPoints,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,Languages,Speed,Proficiencies,DamageResistance,ConditionImmunity,Senses,SpecialAbility,Actions")] Player player)
        {
            //int id = 1;
            player.OwnerID = User.Identity.GetUserId();
            player.GameID = id;
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }
    }
}
