using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepostory repo = new DeneyimRepostory();
        public ActionResult Index()
        {
            var deneyim = repo.List();
            return View(deneyim);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil (int id)
        {

            TblDeneyimlerim t=repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            
            return RedirectToAction("Index");   
        }
        
       
            [HttpGet]
            public ActionResult DeneyimGuncelle(int id)
            {
                var values = repo.TGet(id);
                return View(values);
            }

        [HttpPost]
        public ActionResult DeneyimGuncelle(TblDeneyimlerim p)
        {
            var x = repo.TGet(p.ID);
            x.Baslik = p.Baslik;
            x.AltBaslik = p.AltBaslik;
            x.Aciklama = p.Aciklama;
            x.Tarih = p.Tarih;
            repo.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}