using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EczaDepoUygulama.Models.Entity;


namespace EczaDepoUygulama.Controllers
{
    public class UrunlerController : Controller
    {
        EczaDepoUygulamaEntities ent = new EczaDepoUygulamaEntities();

        public ActionResult Index()
        {
            var model = ent.ilactbl.ToList();
            return View(model);
 
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new ilactbl();
            Yenile(model);
            return View(model);
        }

        private void Yenile(ilactbl model)
        {
            List<kategorilertbl> kategorilist = ent.kategorilertbl.OrderBy(x => x.kategori).ToList();
            model.KategoriListesi = (from x in kategorilist
                                     select new SelectListItem
                                     {
                                         Text = x.kategori,
                                         Value = x.kategori_id.ToString()
                                     }


                                      ).ToList();
            List<birimtbl> birimlist = ent.birimtbl.OrderBy(x => x.birim).ToList();
            model.BirimListesi = (from x in birimlist
                                  select new SelectListItem
                                  {
                                      Text = x.birim,
                                      Value = x.birim_id.ToString()
                                  }).ToList();
        }

        [HttpPost]
        public ActionResult Ekle(ilactbl p)
        {
            if (!ModelState.IsValid)
            {
                var model = new ilactbl();
                Yenile(model);
                return View(model);
            }
            ent.Entry(p).State = System.Data.Entity.EntityState.Added;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetMarka(int id)
        {
            var model = new ilactbl();
            List<markalartbl> markaliste = ent.markalartbl.Where(x => x.kategori_id == id).OrderBy(x => x.marka).ToList();
            model.MarkaListesi = (from x in markaliste
                                  select new SelectListItem
                                  {
                                      Text = x.marka,
                                      Value = x.marka_id.ToString()
                                  }).ToList();
            return Json(model.MarkaListesi, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GuncelleBilgiGetir(int id)
        {
            var model = ent.ilactbl.Find(id);
            Yenile(model);
            List<markalartbl> markalist = ent.markalartbl.Where(x => x.kategori_id == model.kategori_id).OrderBy(x => x.marka).ToList();
            model.MarkaListesi = (from x in markalist
                                  select new SelectListItem
                                  {
                                      Text = x.marka,
                                      Value = x.marka_id.ToString()
                                  }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(ilactbl p)
        {
            if (!ModelState.IsValid)
            {
                var model = ent.ilactbl.Find(p.ilac_id);
                Yenile(model);
                List<markalartbl> markalist = ent.markalartbl.Where(x => x.kategori_id == model.kategori_id).OrderBy(x => x.marka).ToList();
                model.MarkaListesi = (from x in markalist
                                      select new SelectListItem
                                      {
                                          Text = x.marka,
                                          Value = x.marka_id.ToString()
                                      }).ToList();
                return View(model);
            }
            ent.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}