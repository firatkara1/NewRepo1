using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EczaDepoUygulama.Models.Entity;

namespace EczaDepoUygulama.Controllers
{
    public class BirimlerController : Controller
    {
        EczaDepoUygulamaEntities ent = new EczaDepoUygulamaEntities();

        // GET: Birimler
        public ActionResult Index()
        {
            return View(ent.birimtbl.ToList());
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View("Kaydet");
        }

        [HttpPost]
        public ActionResult Kaydet(birimtbl p)
        {
            if (p.birim_id == 0)
            {
                ent.birimtbl.Add(p);

            }
            else
            {
                ent.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }

            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GuncelleBilgiGetir(int? id)
        {
            var model = ent.birimtbl.Find(id);
            return View("Kaydet", model);
        }

        public ActionResult SilBilgiGetirr(int id)
        {
            var model = ent.birimtbl.Find(id);
            return View(model);
        }

        public ActionResult Sil(birimtbl t)
        {
            ent.Entry(t).State = System.Data.Entity.EntityState.Deleted;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}