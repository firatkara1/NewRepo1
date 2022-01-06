using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EczaDepoUygulama.Models.Entity;

namespace EczaDepoUygulama.Controllers
{

    public class KategorilerController : Controller
    {

        EczaDepoUygulamaEntities ent = new EczaDepoUygulamaEntities();

         public ActionResult Index()
        {
            return View(ent.kategorilertbl.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }

        public ActionResult Ekle2(kategorilertbl p)
        {
            if (!ModelState.IsValid) return View("Ekle");
            ent.kategorilertbl.Add(p);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GuncelleBilgiGetir(int id)
        {
            var model = ent.kategorilertbl.Find(id);
              
            return View(model);
        }

        public ActionResult Guncelle(kategorilertbl p)
        {
            ent.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult SilBilgiGetirr(int id)
        {
            var model = ent.kategorilertbl.Find(id);
            return View(model);
        }

        public ActionResult Sil(kategorilertbl t)
        {
            ent.Entry(t).State = System.Data.Entity.EntityState.Deleted;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}