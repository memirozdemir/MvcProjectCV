using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MvcProjectCV.Models.Entity;

namespace MvcProjectCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DBCvSiteEntities db = new DBCvSiteEntities();
        public ActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
        public ActionResult SocialMedia()
        {
            var socialmedia = db.SocialMedias.Where(x=> x.Status==true).ToList();
            return PartialView(socialmedia);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Education()
        {
            var educations = db.Educations.ToList();
            return PartialView(educations);
        }
        public PartialViewResult Skill()
        {
            var skills = db.Skills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Interest()
        {
            var interests = db.Interests.ToList();
            return PartialView(interests);
        }
        public PartialViewResult Certificate()
        {
            var certificates = db.Certificates.ToList();
            return PartialView(certificates);
        }
        [HttpGet]
        public PartialViewResult Communication()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Communication(Communication c)
        {

            c.Date = DateTime.Now;
            db.Communications.Add(c);
            db.SaveChanges();
            return PartialView();
        }
    }
}