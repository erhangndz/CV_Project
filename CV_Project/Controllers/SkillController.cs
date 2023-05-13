using CV_Project.Models.Entity;
using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class SkillController : Controller
    {
        SkillsRepository repo= new SkillsRepository();
       
        public ActionResult Index()
        {
           var values= repo.GetList();
            return View(values);
        }

        public ActionResult DeleteSkill(int id)
        {
            var values= repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values= repo.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill p)
        {
            var x = repo.GetByID(p.SkillID);
            x.SkillName = p.SkillName;
            x.SkillIcon = p.SkillIcon;
            x.Color = p.Color;
            repo.Update(x);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }

    }
}