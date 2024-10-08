using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCV.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExp(Experience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExp(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExp(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExp(Experience p)
        {
            Experience t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle= p.Subtitle;
            t.Date= p.Date;
            t.Description= p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}