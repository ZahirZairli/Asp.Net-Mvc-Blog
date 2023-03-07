using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HomePage(Contact contact)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult results = cv.Validate(contact);

            if (results.IsValid)
            {
                cm.ContactAddBl(contact);
                TempData["message"] = "1";
                return RedirectToAction("HomePage");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    TempData["message"] = "0";
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}