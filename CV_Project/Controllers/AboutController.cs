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
        AboutRepository repo= new AboutRepository();
        public ActionResult Index()
        {
            var values= repo.GetList();
            return View(values);
        }

    }
}