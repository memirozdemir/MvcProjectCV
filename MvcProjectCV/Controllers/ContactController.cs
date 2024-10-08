using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectCV.Models.Entity;
using MvcProjectCV.Repositories;

namespace MvcProjectCV.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Communication> repo = new GenericRepository<Communication>();
        public ActionResult Index()
        {
            var messages = repo.List();
            return View(messages);
        }
    }
}