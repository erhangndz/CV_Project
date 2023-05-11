using CV_Project.Models.Entity;
using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo= new ExperienceRepository();
        public ActionResult Index()
        {
            var values= repo.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddExperience(Experience p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteExperience(int id)
        {
            var values= repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var values= repo.GetByID(id);
            return View(values);    
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experience p)
        {
            var x = repo.GetByID(p.ExperienceID);
            x.Title = p.Title;
            x.Subtitle= p.Subtitle;
            x.Description= p.Description;
            x.Date= p.Date;
            repo.Update(x);
            return RedirectToAction("Index");
        }
    }
}