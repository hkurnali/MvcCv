using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikalarimRepostory repo = new SertifikalarimRepostory();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");

        }
        public ActionResult SertifikaSil( int id)
        {
            var values=repo.TGet(id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {  var values=repo.TGet(id);
           return View(values);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(TblSertifikalarim p)
        {
            var x = repo.TGet(p.ID);
            x.Aciklama = p.Aciklama;
            x.Tarih=p.Tarih;
            repo.TUpdate(x);
            return RedirectToAction("Index");   
        }
}
}