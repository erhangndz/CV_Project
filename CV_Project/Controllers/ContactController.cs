using CV_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Project.Controllers
{
    public class ContactController : Controller
    {
       ContactRepository repo= new ContactRepository();
   
        public ActionResult Index()
        {
           
            var values = repo.GetList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var values= repo.GetByID(id);
            repo.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetContact(int id)
        {
            var values= repo.GetByID(id);
            return View(values);    
        }
    }
}