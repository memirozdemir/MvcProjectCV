using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;

namespace MvcProjectCV.Controllers
{
    public class InterestController : Controller
    {
        GenericRepository<Interest> repo = new GenericRepository<Interest>();
        [HttpGet]
        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }
        [HttpPost]
        public ActionResult Index(Interest p)
        {
           var t = repo.Find(x=>x.ID == 1);
            t.Interest1 = p.Interest1;
            t.Interest2 = p.Interest2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}