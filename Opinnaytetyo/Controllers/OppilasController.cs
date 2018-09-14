using Newtonsoft.Json;
using Opinnaytetyo.Models;
using Opinnaytetyo.ViewModels;
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
        private OpiskelijaTietokantaEntities1 db = new OpiskelijaTietokantaEntities1();
        // GET: Oppilas
        public ActionResult Index()
        {
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
            List<Opiskelija> model = entities.Opiskelija.ToList();
            entities.Dispose();
            return View(model);
        }

        public ActionResult OpiskelijaLista()
        {
            List<OppilasViewModel> model = new List<OppilasViewModel>();
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();

            
            try
            {
                List<Opiskelija> opiskelijat = entities.Opiskelija.ToList();
                foreach (Opiskelija op in opiskelijat)
                {
                    OppilasViewModel ovm = new OppilasViewModel();
                    ovm.OpiskelijaID = op.OpiskelijaID;
                    ovm.Etunimi = op.Etunimi;
                    ovm.Sukunimi = op.Sukunimi;
                    ovm.Puhelin = op.Puhelin;
                    ovm.Email = op.Email;
                    ovm.Osoite = op.Osoite;
                    ovm.Postinumero = op.Postitoimipaikat?.Postinumero;
                    ovm.PostinumeroID = op.Postitoimipaikat?.PostinumeroID;
                    ovm.Postitoimipaikka = op.Postitoimipaikat?.Postitoimipaikka;
                    model.Add(ovm);
                }
                return View(model);
                  
                }
            finally
            {
                entities.Dispose();
            }
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
                             Lisatiedot = op.Lisatiedot
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}