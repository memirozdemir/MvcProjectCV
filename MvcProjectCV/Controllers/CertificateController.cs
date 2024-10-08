using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;

namespace MvcProjectCV.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<Certificate> repo = new GenericRepository<Certificate>();
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult GetCertificate(Certificate t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NewCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCertificate(Certificate p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            repo.TRemove(certificate);
            return RedirectToAction("Index");
        }
    }
}