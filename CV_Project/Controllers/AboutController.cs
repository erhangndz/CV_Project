using CV_Project.Models.Entity;
using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository repo = new AboutRepository();
        public ActionResult Index()
        {
            var values = repo.GetList();
            return View(values);
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = repo.GetByID(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            var x = repo.GetByID(p.AboutID);
            x.ImageURL = p.ImageURL;
            x.Name = p.Name;
            x.Surname = p.Surname;
            x.Description = p.Description;
            x.Address = p.Address;
            x.Phone= p.Phone;
            x.Mail= p.Mail;
            repo.Update(x);
            return RedirectToAction("Index");

        }


    }
}