using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;

namespace MvcProjectCV.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var listing = repo.List();
            return View(listing);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminRemove(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin p)
        {
            Admin t = repo.Find(x => x.ID == p.ID);
            t.Username = p.Username;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}