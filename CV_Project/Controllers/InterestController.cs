using CV_Project.Models.Entity;
using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class InterestController : Controller
    {
       InterestRepository repo= new InterestRepository();
       
        public ActionResult Index()
        {
            var values= repo.GetList();
            return View(values);
        }

        public ActionResult DeleteInterest(int id)
        {
            var values = repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddInterest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInterest(Interest p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInterest(int id)
        {
            var values = repo.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateInterest(Interest p)
        {
            var x = repo.GetByID(p.InterestID);
           
            x.Description1 = p.Description1;
            x.Description2 = p.Description2;
            repo.Update(x);
            return RedirectToAction("Index");
        }
    }
}