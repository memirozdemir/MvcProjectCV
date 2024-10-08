using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCV.Controllers
{
    
    public class EducationController : Controller
    {
        GenericRepository<Education> repo = new GenericRepository<Education>();
        
        public ActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education p)
        {
            if (ModelState.IsValid)
            {
                repo.TAdd(p);
                TempData["SuccessMessage"] = "Education submitted successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddEducation");
            }
        }
        public ActionResult DeleteEducation(int id)
        {

            var education = repo.Find(x => x.ID == id);
            if (education != null)
            {
                repo.TRemove(education);  // Silme işlemi
                TempData["SuccessMessage"] = "Record deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Record not found!";
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult EditEducation(Education t)
        {
            var education = repo.Find(x => x.ID == t.ID);
            education.Title = t.Title;
            education.Subtitle1 = t.Subtitle1;
            education.Subtitle2 = t.Subtitle2;
            education.AvgNote = t.AvgNote;
            education.Date = t.Date;
            if (ModelState.IsValid)
            {
                repo.TUpdate(education);
                TempData["SuccessMessage"] = "Education updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditEducation");
            }
            
        }
    }
}