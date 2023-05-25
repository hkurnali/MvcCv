using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        EgitimRepostory repo = new EgitimRepostory();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult EgitimSil(int id)
        {
            var values=repo.TGet(id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim e)
        {  if (!ModelState.IsValid )
            {

                return View("EgitimEkle");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            var values = repo.TGet(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EgitimGuncelle(TblEgitimlerim p)
        {
            var e= repo.TGet(p.ID);
            e.Baslik=p.Baslik;
            e.AltBaslik1=p.AltBaslik1;
            e.AltBaslik2=p.AltBaslik2;
            e.GNO=p.GNO;
            e.Tarih=p.Tarih;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}