using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DDToolKit.Controllers
{
    public class EquipmentController : Controller
    {
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

        // GET: Equipment

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string equipName)
        {
            string json = SendRequest("https://www.dnd5eapi.co/api/equipment");
            JObject data = JObject.Parse(json);

            List<string> list = new List<string>();

            for (int i = 0; i < (int)data["count"]; i++)
            {
                string current = (string)data["results"][i]["name"];
                if (current.Contains(equipName) == true)
                {
                    list.Add((string)data["results"][i]["index"]);
                }
            }

            ViewBag.EquipList = list;
            ViewBag.Success = true;
            return View();
        }


        public ActionResult equipInfo(string equipName)
        {
            string json = SendRequest("https://www.dnd5eapi.co/api/equipment/" + equipName);

            JObject data = JObject.Parse(json);



            string name, equipCategory, vehicleCategory, gearCategoty, toolCategoty, unit,
                weaponCategory, weaponRange, categoryRange, damageDice, damageTypeName, damageTypeUrl,
                 damage2hDamageDice, ArmorClassDexBonus, rangeLong, longThrowRange,
               damage2hDamageType, armorCategory, ArmorClassMaxBonus, strMin, stealthDisadvantage, contents,
                speedUnit, capacity;

            int? damageBounc, weight, quantity, rangeNormal, damage2hDamageBounc, armorClassBase, normalThrowRange, speedQuantity;
            name = (string)data["name"];

            if (data["equipment_category"] != null)
            {
                equipCategory = (string)data["equipment_category"];
            }
            else
            {
                equipCategory = null;
            }

            if (data["vehicle_category"] != null)
            {
                vehicleCategory = (string)data["vehicle_category"];
            }
            else
            {
                vehicleCategory = null;
            }

            if (data["gear_category"] != null)
            {
                gearCategoty = (string)data["gear_category"];
            }
            else
            {
                gearCategoty = null;
            }

            if (data["tool_category"] != null)
            {
                toolCategoty = (string)data["tool_category"];
            }
            else
            {
                toolCategoty = null;
            }

            if (data["cost"] != null)
            {
                unit = (string)data["cost"]["unit"];
            }
            else
            {
                unit = null;
            }

            if (data["cost"] != null)
            {
                quantity = (int)data["cost"]["quantity"];
            }
            else
            {
                quantity = null;
            }

            if (data["weight"] != null)
            {
                weight = (int)data["weight"];
            }
            else
            {
                weight = null;
            }

            List<string> desc = new List<string>();
            if (data["desc"] != null)
            {

                for (int i = 0; i < data["desc"].Count(); i++)
                {
                    desc.Add((string)data["desc"][i]);


                }
            }
            else
            {

                desc = null;

            }

            if (data["weapon_category"] != null)
            {
                weaponCategory = (string)data["weapon_category"];
            }
            else
            {
                weaponCategory = null;
            }

            if (data["weapon_range"] != null)
            {
                weaponRange = (string)data["weapon_range"];
            }
            else
            {
                weaponRange = null;
            }

            if (data["category_range"] != null)
            {
                categoryRange = (string)data["category_range"];
            }
            else
            {
                categoryRange = null;
            }

            if (data["damage"] != null)
            {
                damageDice = (string)data["damage"]["damage_dice"];
            }
            else
            {
                damageDice = null;
            }

            if (data["damage"] != null)
            {
                damageBounc = (int)data["damage"]["damage_bonus"];
            }
            else
            {
                damageBounc = null;
            }

            if (data["damage"] != null)
            {
                damageTypeName = (string)data["damage"]["damage_type"]["name"];
            }
            else
            {
                damageTypeName = null;
            }

            if (data["damage"] != null)
            {
                damageTypeUrl = (string)data["damage"]["damage_type"]["url"];
            }
            else
            {
                damageTypeUrl = null;
            }

            if (data["range"] != null)
            {
                rangeNormal = (int)data["range"]["normal"];
            }
            else
            {
                rangeNormal = null;
            }

            if (data["range"] != null)
            {
                rangeLong = (string)data["range"]["long"];
            }
            else
            {
                rangeLong = null;
            }

            List<string> prepertyUrl = new List<string>();
            if (data["properties"] != null)
            {

                for (int i = 0; i < data["properties"].Count(); i++)
                {
                    prepertyUrl.Add((string)data["properties"][i]["url"]);


                }
            }
            else
            {

                prepertyUrl = null;

            }

            List<string> prepertyName = new List<string>();
            if (data["properties"] != null)
            {

                for (int i = 0; i < data["properties"].Count(); i++)
                {
                    prepertyName.Add((string)data["properties"][i]["name"]);


                }
            }
            else
            {

                prepertyName = null;

            }

            List<string> special = new List<string>();
            if (data["special"] != null)
            {

                for (int i = 0; i < data["special"].Count(); i++)
                {
                    special.Add((string)data["special"][i]);


                }
            }
            else
            {

                special = null;

            }

            if (data["2h_damage"] != null)
            {
                damage2hDamageDice = (string)data["2h_damage"]["damage_dice"];
            }
            else
            {
                damage2hDamageDice = null;
            }

            if (data["2h_damage"] != null)
            {
                damage2hDamageBounc = (int)data["2h_damage"]["damage_bonus"];
            }
            else
            {
                damage2hDamageBounc = null;
            }

            if (data["2h_damage"] != null)
            {
                damage2hDamageType = (string)data["2h_damage"]["damage_type"]["name"];
            }
            else
            {
                damage2hDamageType = null;
            }

            if (data["armor_category"] != null)
            {
                armorCategory = (string)data["armor_category"];
            }
            else
            {
                armorCategory = null;
            }

            if (data["armor_class"] != null)
            {
                armorClassBase = (int)data["armor_class"]["base"];
            }
            else
            {
                armorClassBase = null;
            }

            if (data["armor_class"] != null)
            {
                ArmorClassDexBonus = (string)data["armor_class"]["dex_bonus"];
            }
            else
            {
                ArmorClassDexBonus = null;
            }

            if (data["armor_class"] != null)
            {
                ArmorClassMaxBonus = (string)data["armor_class"]["max_bonus"];
            }
            else
            {
                ArmorClassMaxBonus = null;
            }

            if (data["str_minimum"] != null)
            {
                strMin = (string)data["str_minimum"];
            }
            else
            {
                strMin = null;
            }

            if (data["stealth_disadvantage"] != null)
            {
                stealthDisadvantage = (string)data["stealth_disadvantage"];
            }
            else
            {
                stealthDisadvantage = null;
            }

            if (data["speed"] != null)
            {
                speedQuantity = (int)data["speed"]["quantity"];
            }
            else
            {
                speedQuantity = null;
            }

            if (data["speed"] != null)
            {
                speedUnit = (string)data["speed"]["unit"];
            }
            else
            {
                speedUnit = null;
            }

            if (data["capacity"] != null)
            {
                capacity = (string)data["capacity"];
            }
            else
            {
                capacity = null;
            }

            if (data["throw_range"] != null)
            {
                normalThrowRange = (int)data["throw_range"]["normal"];
            }
            else
            {
                normalThrowRange = null;
            }

            if (data["throw_range"] != null)
            {
                longThrowRange = (string)data["throw_range"]["long"];
            }
            else
            {
                longThrowRange = null;
            }









            ViewBag.name = name;
            ViewBag.equipCategory = equipCategory;
            ViewBag.desc = desc;
            ViewBag.vehicleCategory = vehicleCategory;
            ViewBag.gearCategory = gearCategoty;
            ViewBag.toolCategory = toolCategoty;
            ViewBag.quantity = quantity;
            ViewBag.unit = unit;
            ViewBag.weight = weight;

            ViewBag.weaponCategory = weaponCategory;
            ViewBag.weaponRange = weaponRange;
            ViewBag.categoryRange = categoryRange;
            ViewBag.damageDice = damageDice;
            ViewBag.damageBounc = damageBounc;
            ViewBag.damageTypeName = damageTypeName;
            ViewBag.damageTypeUrl = damageTypeUrl;
            ViewBag.rangeNormal = rangeNormal;
            ViewBag.rangeLong = rangeLong;
            ViewBag.prepertyUrl = prepertyUrl;

            ViewBag.prepertyName = prepertyName;
            ViewBag.damage2hDamageDice = damage2hDamageDice;
            ViewBag.damage2hDamageBounc = damage2hDamageBounc;
            ViewBag.damage2hDamageType = damage2hDamageType;
            ViewBag.armorCategory = armorCategory;
            ViewBag.armorClassBase = armorClassBase;
            ViewBag.armorClassDexBonus = ArmorClassDexBonus;
            ViewBag.ArmorClassMaxBonus = ArmorClassMaxBonus;
            ViewBag.special = special;
            ViewBag.strMinimum = strMin;
            ViewBag.stealthDisadvan = stealthDisadvantage;
            ViewBag.speedQuantity = speedQuantity;
            ViewBag.speedUnit = speedUnit;
            ViewBag.capacity = capacity;
            ViewBag.normalThrowRange = normalThrowRange;
            ViewBag.longThrowRange = longThrowRange;

            ViewBag.Success = true;

            return View();

        }


    }
}