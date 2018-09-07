using Newtonsoft.Json;
using Opinnaytetyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Opinnaytetyo.Controllers
{
    public class OppilasController : Controller
    {
        // GET: Oppilas
        public ActionResult Index()
        {
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
            List<Opiskelija> model = entities.Opiskelija.ToList();
            entities.Dispose();

            return View(model);
        }
        public JsonResult HaeLista()
        {
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
            //  List<Opiskelija> model = entities.Opiskelija.ToList();

            var model = (from op in entities.Opiskelija
                         select new
                         {
                             OpiskelijaID = op.OpiskelijaID,
                             Etunimi = op.Etunimi,
                             Sukunimi = op.Sukunimi,
                             Puhelin = op.Puhelin,
                             Email = op.Email,
                             Osoite = op.Osoite,
                             Postinumero = op.Postinumero,
                             Lisatiedot = op.Lisatiedot
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HaeYksittainenOpiskelija(int id)
        {
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
            //  List<Opiskelija> model = entities.Opiskelija.ToList();

            var model = (from op in entities.Opiskelija
                         where op.OpiskelijaID == id
                         select new
                         {
                             OpiskelijaID = op.OpiskelijaID,
                             Etunimi = op.Etunimi,
                             Sukunimi = op.Sukunimi,
                             Puhelin = op.Puhelin,
                             Email = op.Email,
                             Osoite = op.Osoite,
                             Postinumero = op.Postinumero,
                             Lisatiedot = op.Lisatiedot
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}