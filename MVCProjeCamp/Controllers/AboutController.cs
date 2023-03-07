using BusinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [Authorize(Roles = "A,B")]
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var abouts = am.GetList();
            return View(abouts);
        }
        public ActionResult AddAbout(About about)
        {
            am.AddAboutBl(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult EditAbout(int id)
        {
            var about = am.GetById(id);
            if (about.AboutStatus == true)
            {
                about.AboutStatus = false;
                am.AboutUpdate(about);
            }
            else
            {
                if (am.GetActiveList().Count >= 1)
                {
                    TempData["message"] = "Zəhmət olmasa bir aktiv xananı seçin!Saytda sadəcə 1 haqqımda bölməsi var.";
                }
                else
                {
                    about.AboutStatus = true;
                    am.AboutUpdate(about);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
