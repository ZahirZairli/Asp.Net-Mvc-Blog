using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    public class WriterPanelHeadingController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading()
        {
            int id;
            string p;
            p = (string)Session["WriterMail"];
            var writer = wm.GetByMailSession(p);
            id = writer.WriterId;
            var heading = hm.GetListtByWriterId(id);
            return View(heading);
        }
        public ActionResult AllHeading(int page = 1)
        {
            var heading = hm.GetList().FindAll(x=>x.HeadingStatus == true).ToPagedList(page,5);
            return View(heading);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,   //optionun metni
                                                   Value = x.CategoryId.ToString()    //optionun valuesi
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading newHeading)
        {
            HeadingValidator hv = new HeadingValidator();
            ValidationResult results = hv.Validate(newHeading);

            int id;
            string p;
            p = (string)Session["WriterMail"];
            var writer = wm.GetByMailSession(p);
            id = writer.WriterId;

            newHeading.WriterId = id;
            if (results.IsValid)
            {
                newHeading.HeadingDate = DateTime.Now;
                hm.AddHeadingBl(newHeading);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,   //optionun metni
                                                   Value = x.CategoryId.ToString()    //optionun valuesi
                                               }).ToList();
            ViewBag.categories = categories;
            var heading = hm.GetByID(id);
            return View(heading);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {

            int id;
            id = (int)Session["WriterId"];


            if (heading.WriterId == id)
            {
                hm.UpdateHeadingBl(heading);
            }
               return RedirectToAction("MyHeading");
        }


        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetByID(id);
            heading.HeadingStatus = false;
            hm.DeleteHeadingBl(heading);
            TempData["messagedelete"] = "Əməliyyat uğurla icra edildi.Statusunu dəyişdiyiniz başlıq saytda görsənməyəcəkdir";
            return RedirectToAction("MyHeading");
        }
        public ActionResult RestoreHeading(int id)
        {
            var heading = hm.GetByID(id);
            heading.HeadingStatus = true;
            hm.RestoreHeadingBl(heading);
            TempData["messagerestore"] = "Əməliyyat uğurla icra edildi.Statusunu dəyişdiyiniz başlıq saytda görsənəcəkdir";
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeadingMain(int id)
        {
            var heading = hm.GetByID(id);
            hm.DeleteHeadingMainBl(heading);
            TempData["messagedelete"] = "Əməliyyat uğurla icra edildi.Seçmiş olduğunuz başlıq qalıcı olaraq silindi.";
            return RedirectToAction("MyHeading");
        }
    }
}