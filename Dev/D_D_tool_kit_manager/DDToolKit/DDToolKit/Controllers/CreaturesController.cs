using DDToolKit.DAL;
using DDToolKit.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DDToolKit.Controllers
{
    public class CreaturesController : Controller
    {
        private Monsters db = new Monsters();

        public List<string> TrimProficiency(Creature creature)
        {
            var prof = creature.Proficiencies.Split(';');
            List<string> proficiency = new List<string>();
            string name = "";
            foreach (var stat in prof)
            {
                if (stat.Contains("name"))
                {
                    var attrib = stat.Split(':');
                    name = attrib[1] + ":" + attrib[2];
                }
                if (stat.Contains("value") || stat.Contains("desc"))
                {
                    var attrib = stat.Split(':');
                    string value = attrib[1];
                    string trim = name + " " + value;
                    string trimmed = trim.Trim(new char[] { ']', '[', '{', '}' });
                    trimmed = trimmed.Replace("'", "");
                    proficiency.Add(trimmed);
                }
            }
            return proficiency;
        }

        public List<string> TrimAction(string act)
        {
            if (act == null)
                return null;

            act = act.Replace(";", ",");
            act = act.Replace("'", "\"");
            char[] trim = act.ToCharArray();
            for (int i = 0; i < trim.Length - 1; i++)
            {
                if (trim[i] == '\"')
                {
                    if (char.IsLetter(trim[i - 1]) && char.IsLetter(trim[i + 1]))
                    {
                        trim[i] = '\'';
                    }
                }
            }
            string test = new string(trim);
            JArray json = JArray.Parse(test);
            List<string> actions = new List<string>();

            foreach (var action in json)
            {
                actions.Add(action["name"] + ": " + action["desc"]);
            }


            return actions;
        }

        public string TrimString(string text)
        {
            if (text != "[]" || text != "{}")
            {
                text = text.Replace("'", "");
                text = text.Replace(";", ",");
                text = text.Replace("[", "");
                text = text.Replace("]", "");
                text = text.Replace("{", "");
                text = text.Replace("}", "");
            }
            else
            {
                text = "";
            }
            return text;
        }

        public List<string> TrimAbilities(Creature creature)
        {
            if (creature.SpecialAbilities == null)
                return null;
            List<string> abilities = new List<string>();
            string ability = creature.SpecialAbilities;

            return abilities;
        }


        // GET: Creatures
        public ActionResult Index()
        {
            return View(db.Creatures.ToList());
        }


        [HttpPost]
        public ActionResult Index(String SearchName)
        {
            var Res = db.Creatures.Where(p => p.Name.Contains(SearchName)).ToList();
            ModelState.Clear();
            return View(Res);
        }


        // GET: Creatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creature creature = db.Creatures.Find(id);
            if (creature == null)
            {
                return HttpNotFound();
            }

            List<string> prof = TrimProficiency(creature);
            List<string> action = TrimAction(creature.Actions);
            List<string> legendary = TrimAction(creature.LegendaryActions);



            ViewBag.Abilites = TrimAbilities(creature);
            ViewBag.Senses = TrimString(creature.Senses);
            ViewBag.Immunity = TrimString(creature.DamageImmunities);
            ViewBag.Speed = TrimString(creature.Speed);
            ViewBag.DamageVuln = TrimString(creature.DamageVulnerabilities);
            ViewBag.DamageResist = TrimString(creature.DamageResistances);
            ViewBag.ConditionImmun = TrimString(creature.ConditionImmunities);
            ViewBag.action = action;
            ViewBag.prof = prof;
            ViewBag.Legendary = legendary;
            ViewBag.Reaction = TrimAction(creature.Reactions);
            return View(creature);
        }

        // GET: Creatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Creatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Size,Type,Subtype,Alignment,ArmorClass,HitPoints,HitDice,Speed,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,Proficiencies,DamageVulnerabilities,DamageResistances,DamageImmunities,ConditionImmunities,Senses,Languages,ChallengeRating,SpecialAbilities,Actions,LegendaryActions,Reactions")] Creature creature)
        {
            if (ModelState.IsValid)
            {
                db.Creatures.Add(creature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creature);
        }

        // GET: Creatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creature creature = db.Creatures.Find(id);
            if (creature == null)
            {
                return HttpNotFound();
            }
            return View(creature);
        }

        // POST: Creatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Size,Type,Subtype,Alignment,ArmorClass,HitPoints,HitDice,Speed,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,Proficiencies,DamageVulnerabilities,DamageResistances,DamageImmunities,ConditionImmunities,Senses,Languages,ChallengeRating,SpecialAbilities,Actions,LegendaryActions,Reactions")] Creature creature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creature);
        }

        // GET: Creatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creature creature = db.Creatures.Find(id);
            if (creature == null)
            {
                return HttpNotFound();
            }
            return View(creature);
        }

        // POST: Creatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Creature creature = db.Creatures.Find(id);
            db.Creatures.Remove(creature);
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

        private string SendRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            //request.Headers.Add("Authorization", "token " + credentials);
            //request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        [HttpGet]
        public ActionResult Spells()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spells(string SpellName)
        {
            string json = SendRequest("https://www.dnd5eapi.co/api/spells");
            JObject data = JObject.Parse(json);
            string firstName = (string)data["results"][0]["name"];
            firstName = IsString(firstName);
            List<string> list = new List<string>();

            for (int i = 0; i < (int)data["count"]; i++)
            {
                string current = (string)data["results"][i]["name"];
                if (current.Contains(SpellName) == true)
                {
                    list.Add((string)data["results"][i]["name"]);
                }
            }

            // debugin to test the output.
            /*for (int j = 0; j < list.Count(); j++)
            {
                Debug.WriteLine(list[j]);
            }*/

            //return jsonString;

            ViewBag.SpellsList = list;
            ViewBag.Success = true;
            return View();
        }

        public string IsString(string name)
        {
            if (name == null)
            {
                return "Name is null";
            }
            return name;
        }
    }
}
