using CV_Project.Models.Entity;
using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository repo = new EducationRepository();
       
        public ActionResult Index()
        {
            var values= repo.GetList();
            return View(values);
        }

        public ActionResult DeleteEducation(int id)
        {
            var values= repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            repo.Insert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values= repo.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education p)
        {
            var x = repo.GetByID(p.EducationID);
            x.Title = p.Title;
            x.Subtitle1 = p.Subtitle1;
            x.Subtitle2 = p.Subtitle2;
            x.AvgGrade = p.AvgGrade;
            x.Date = p.Date;
            repo.Update(x);
            return RedirectToAction("Index");
            
        }
    }
}