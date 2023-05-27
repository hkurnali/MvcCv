using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        DbCvEntities1 db= new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public  PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
           
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);

        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);

        }
        public PartialViewResult Hobilerim ()
        {
            var hobim = db.TblHobilerim.ToList();
            return PartialView(hobim);

        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);

        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim p)
        {
            p.Tarih =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(p);
            db.SaveChanges();
            
            return PartialView();
        }
       
    }
}