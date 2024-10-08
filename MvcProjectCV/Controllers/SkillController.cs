using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;

namespace MvcProjectCV.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<Skill> repo = new GenericRepository<Skill>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult NewSkill() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult NewSkill(Skill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x=>x.ID == id);
            repo.TRemove(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Skill1 = t.Skill1;
            y.Rate=t.Rate;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}