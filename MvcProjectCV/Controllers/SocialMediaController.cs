using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;

namespace MvcProjectCV.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetPage(int id)
        {
            var acc = repo.Find(x => x.ID == id);
            return View(acc);
        }
        [HttpPost]
        public ActionResult GetPage(SocialMedia p)
        {
            var acc = repo.Find(x => x.ID == p.ID);
            acc.Name = p.Name;
            acc.Status = true;
            acc.Link = p.Link;
            acc.Icon = p.Icon;
            repo.TUpdate(acc);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var acc = repo.Find(x=>x.ID == id);
            acc.Status = false;
            repo.TUpdate(acc);
            return RedirectToAction("Index");
        }
    }
}