using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repostories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepostory repo=new YetenekRepostory();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
        return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var values = repo.TGet(id);

            repo.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var values = repo.TGet(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult YetenekGuncelle(TblYeteneklerim p)
        {
            var x = repo.TGet(p.ID);
            x.Yetenek = p.Yetenek;
            x.Oran = p.Oran;
           
            repo.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}