using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EczaDepoUygulama.Models.Entity;


namespace EczaDepoUygulama.Controllers
{
    public class MarkalarController : Controller
    {
        EczaDepoUygulamaEntities ent = new EczaDepoUygulamaEntities();

        public ActionResult Index()
        {
            var model = ent.markalartbl.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            SelecteBilgiGetir();
            return View();
            // /*ViewBag*/.kategori_id = new SelectList(ent.kategorilertbl, "kategori_id", "kategori", model.kategori_id);

        }

        private void SelecteBilgiGetir()
        {
            var model = new markalartbl();
            List<SelectListItem> liste = new List<SelectListItem>(from x in ent.kategorilertbl
                                                                  select new SelectListItem
                                                                  {
                                                                      Value = x.kategori_id.ToString(),
                                                                      Text = x.kategori
                                                                  }

                                                                   ).ToList();
            ViewBag.l = liste;
        }


        [HttpPost]
        public ActionResult Ekle(markalartbl m)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.kategori_id = new SelectList(ent.kategorilertbl, "kategori_id", "kategori", m.kategori_id);
                return View();
            }
            ent.Entry(m).State = System.Data.Entity.EntityState.Added;
            ent.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GuncelleBilgiGetir(int id)
        {
            SelecteBilgiGetir();
            var ara = ent.markalartbl.Find(id);
            return View(ara);
        }

        public ActionResult Guncelle(markalartbl p)
        {
            if (!ModelState.IsValid)
            {
                SelecteBilgiGetir();
                return View("GuncelleBilgiGetir");
            }
            ent.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(int id)
        {
            var getir = ent.markalartbl.Find(id);
            return View(getir);
        }
        public ActionResult Sil(markalartbl p)
        {
            ent.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}