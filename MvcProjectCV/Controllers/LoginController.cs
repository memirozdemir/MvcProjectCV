using MvcProjectCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            DBCvSiteEntities db = new DBCvSiteEntities();
            var info = db.Admins.FirstOrDefault(x=> x.Username == p.Username && x.Password==p.Password);
            if (info != null) 
            { 
                FormsAuthentication.SetAuthCookie(info.Username,false);
                Session["Username"]=info.Username.ToString();
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}