using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCV.Controllers
{
    public class AboutController : Controller
    {
        DBCvSiteEntities db = new DBCvSiteEntities();
        GenericRepository<About> repo = new GenericRepository<About>();
        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(About p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.Description = p.Description;
            t.Picture = p.Picture;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}