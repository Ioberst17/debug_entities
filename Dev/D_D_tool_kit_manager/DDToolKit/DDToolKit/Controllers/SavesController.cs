using DDToolKit.DAL;
using DDToolKit.Models;
using Microsoft.AspNet.Identity;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Data.Entity;
using System.Data.Entity;
using System.Linq;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DDToolKit.Controllers
{
    public class SavesController : Controller
    {
        private gameModel db = new gameModel();
        private Monsters dbMonsters = new Monsters();
        private Map dbmap = new Map();
        private Magic dbMagic = new Magic();


        // GET: Saves
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            return View(db.Saves.Where(s => s.OwnerID.Contains(id)).ToList());
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
            ViewBag.Monsters = new SelectList(dbMonsters.Creatures, "Name", "Name");
            ViewBag.Magic = new SelectList(db.Magics, "Name", "Name");
            return View();
        }

        // POST: Saves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,OwnerID,Monster1,Monster2,Monster3,Monster4,Monster5,Monster6,Monster7,Monster8,Monster9,Monster10,Monster11,Monster12,Monster13,Monster14,Monster15,Monster16,Monster17,Monster18,Monster19,Monster20,Magic")] Save save)
        {

            save.OwnerID = User.Identity.GetUserId();
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
            ViewBag.Monsters = new SelectList(dbMonsters.Creatures, "Name", "Name");
            ViewBag.Magic = new SelectList(db.Magics, "Name", "Name");
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
        public ActionResult Edit([Bind(Include = "ID,Name,OwnerID,Monster1,Monster2,Monster3,Monster4,Monster5,Monster6,Monster7,Monster8,Monster9,Monster10,Monster11,Monster12,Monster13,Monster14,Monster15,Monster16,Monster17,Monster18,Monster19,Monster20,Magic")] Save save)
        {
            save.OwnerID = User.Identity.GetUserId();
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
        // GET: Saves/MapSetup
        public ActionResult MapSetup(int? id)
        {
            return View();
        }

        // POST: Saves/MapSetup
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MapSetup(int id, [Bind(Include = "ID,Name,MapWidth,MapHeight")] Map map)
        {
            string temp = new string('1', 400);
            map.OwnerID = User.Identity.GetUserId();
            map.GameID = id;
            map.MapLand = temp;
            map.MapObjects = temp;
            if (ModelState.IsValid)
            {
                db.Maps.Add(map);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(map);
        }

        public ActionResult MapEdit(int? id)
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

            player.Size = PlayerAttributeFiller(player.Size);
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

        public string PlayerAttributeFiller(string current)
        {
            if (current == null)
            {
                current = "No Data";
            }
            return current;
        }

        public ActionResult Game(int? id, int? mapid)
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
            if (mapid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Find(mapid);
            if (map == null)
            {
                return HttpNotFound();
            }

            //Passing in monster data from saves through viewbags.
            int temp;
            if (save.Monster1 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster1) select creatures.ID).Single(); ViewBag.mon1 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster2 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster2) select creatures.ID).Single(); ViewBag.mon2 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster3 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster3) select creatures.ID).Single(); ViewBag.mon3 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster4 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster4) select creatures.ID).Single(); ViewBag.mon4 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster5 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster5) select creatures.ID).Single(); ViewBag.mon5 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster6 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster6) select creatures.ID).Single(); ViewBag.mon6 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster7 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster7) select creatures.ID).Single(); ViewBag.mon7 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster8 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster8) select creatures.ID).Single(); ViewBag.mon8 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster9 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster9) select creatures.ID).Single(); ViewBag.mon9 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster10 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster10) select creatures.ID).Single(); ViewBag.mon10 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster11 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster11) select creatures.ID).Single(); ViewBag.mon11 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster12 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster12) select creatures.ID).Single(); ViewBag.mon12 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster13 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster13) select creatures.ID).Single(); ViewBag.mon13 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster14 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster14) select creatures.ID).Single(); ViewBag.mon14 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster15 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster15) select creatures.ID).Single(); ViewBag.mon15 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster16 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster16) select creatures.ID).Single(); ViewBag.mon16 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster17 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster17) select creatures.ID).Single(); ViewBag.mon17 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster18 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster18) select creatures.ID).Single(); ViewBag.mon18 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster19 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster19) select creatures.ID).Single(); ViewBag.mon19 = dbMonsters.Creatures.Find(temp); }
            if (save.Monster20 != null) { temp = (from creatures in dbMonsters.Creatures where (creatures.Name == save.Monster20) select creatures.ID).Single(); ViewBag.mon20 = dbMonsters.Creatures.Find(temp); }

            ViewBag.mapheight = map.MapHeight;
            ViewBag.mapwidth = map.MapWidth;
            ViewBag.mapland = map.MapLand;
            return View(db.Players.ToList().Where(s => s.GameID == id));
        }
    }
}
