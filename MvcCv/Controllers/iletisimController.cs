using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
       iletisimRepostory repo=new iletisimRepostory();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult iletisimSil(int id)
        {  var values=repo.TGet(id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Getiletisim(int id)
        {
            var values = repo.TGet(id);
            return View(values);
        }
    }  
}