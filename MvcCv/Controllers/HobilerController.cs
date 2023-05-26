using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobilerController : Controller
    {
        HobiRepostory repo=new HobiRepostory();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult HobilerSil(int id)
        {
            var values=repo.TGet(id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HobilerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobilerEkle(TblHobilerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HobilerGuncelle(int id)
        {
            var values = repo.TGet(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult HobilerGuncelle(TblHobilerim p)
        {
            var x = repo.TGet(p.ID);
            x.Aciklama1 = p.Aciklama1;
            x.Aciklama2 = p.Aciklama2;
            repo.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}