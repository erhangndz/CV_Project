using CV_Project.Models.Entity;
using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class CertificateController : Controller
    {
      CertificateRepository repo = new CertificateRepository();
       
        public ActionResult Index()
        {
            var values= repo.GetList();
            return View(values);
        }

        public ActionResult DeleteCertificate(int id)
        {
            var values= repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public ActionResult UpdateCertificate(int id) 
        {
        var values= repo.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(Certificate p)
        {
            var x = repo.GetByID(p.CertifiacateID);
            x.Description = p.Description;
            x.Date= p.Date;
            repo.Update(x);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(Certificate p)
        {
            repo.Insert(p);
            return RedirectToAction("Index");
        }
    }
}