using CV_Project.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

namespace CV_Project.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        DbCVEntities db= new DbCVEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p )
        {
            var values = db.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (values != null) { FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username;
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
          
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}