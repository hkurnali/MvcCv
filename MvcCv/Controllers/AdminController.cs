using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
   
    public class AdminController : Controller
    {
       GenericRepostory<TblAdmin> repo=new
            GenericRepostory<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        public ActionResult AdminSil(int id)
        {
            var values = repo.TGet(id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle( TblAdmin p)
        {

            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var values = repo.TGet(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin p)
        {
            var e = repo.TGet(p.ID);
            e.KullaniciAdi = p.KullaniciAdi;
            e.Sifre=p.Sifre;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}