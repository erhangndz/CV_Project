using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Project.Models.Entity;

namespace CV_Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
    
        DbCVEntities db= new DbCVEntities();
        public ActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var values= db.Experiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult Education()
        {
            var values= db.Educations.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skills()
        {
            var values = db.Skills.ToList();
            return PartialView(values);
        }

        public PartialViewResult Interests()
        {
            var values = db.Interests.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certificates()
        {
            var values = db.Certificates.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult Contacts()
        {
         
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contacts(Contact p)
        {
            p.Date = DateTime.Parse( DateTime.Now.ToShortDateString());
            db.Contacts.Add(p);
            db.SaveChanges();
            return PartialView();
        }

    }
}