using Opinnaytetyo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Opinnaytetyo.Controllers
{
    public class AccountController : Controller
      
    {
        private OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult KayttajaListaus()
        {
            OpiskelijaTietokantaEntities1 entities = new OpiskelijaTietokantaEntities1();
            List<Kayttajatunnukset> model = entities.Kayttajatunnukset.ToList();
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Kayttajatunnukset model)
        {
            Kayttajatunnukset view = new Kayttajatunnukset();
            view.KayttajatunnusID = model.KayttajatunnusID;
            view.Kayttajatunnus = model.Kayttajatunnus;
            view.Salasana = model.Salasana;
            view.RekisteröiytmisPVM = DateTime.Now;
          
            entities.Kayttajatunnukset.Add(view);
            try
            {
                entities.SaveChanges();
            }
            finally
            {
                entities.Dispose();
            }
            return RedirectToAction("Register");
        }

    }


}