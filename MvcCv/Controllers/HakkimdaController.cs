using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        HakkimdaRepostory repo=new HakkimdaRepostory();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult HakkimdaSil(int id)
        {
            var values = repo.TGet(id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HakkimdaGuncelle(int id)
        {
            var values = repo.TGet(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult HakkimdaGuncelle(TblHakkimda p)
        {
            var x = repo.TGet(p.ID);
            x.Resim = p.Resim;
            x.Ad = p.Ad;
            x.Soyad = p.Soyad;
            x.Aciklama = p.Aciklama;
            x.Adres = p.Adres;
            x.Telefon = p.Telefon;
            x.Mail = p.Mail;
            repo.TUpdate(x);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SocialMediaGuncelle(int id)
        {
            var values = repo.TGet(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult SocialMediaGuncelle(TblHakkimda p)
        {
            var x = repo.TGet(p.ID);
            x.Linkedin = p.Linkedin;
            x.Github = p.Github;
            x.Instagram = p.Instagram;
            x.Facebook = p.Facebook;
            repo.TUpdate(x);
            return RedirectToAction("Index");

        }
    }
}