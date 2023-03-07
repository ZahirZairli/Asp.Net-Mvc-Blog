using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [Authorize(Roles = "A,B")]
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Heading
        public ActionResult Index(int page = 1)
        {
            var headingValues = hm.GetList().ToPagedList(page,5);
            return View(headingValues);
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetByID(id);
            heading.HeadingStatus = false;
            hm.DeleteHeadingBl(heading);
            TempData["messagedelete"] = "Əməliyyat uğurla icra edildi.Statusunu dəyişdiyiniz başlıq saytda görsənməyəcəkdir";
            return RedirectToAction("Index");
        }
        public ActionResult RestoreHeading(int id)
        {
            var heading = hm.GetByID(id);
            heading.HeadingStatus = true;
            hm.RestoreHeadingBl(heading);
            TempData["messagerestore"] = "Əməliyyat uğurla icra edildi.Statusunu dəyişdiyiniz başlıq saytda görsənəcəkdir";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,   //optionun metni
                                                   Value = x.CategoryId.ToString()    //optionun valuesi
                                               }).ToList();
            ViewBag.categories = categories;
            List<SelectListItem> writers = (from x in wm.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterName + ' ' + x.WriterSurname,   //optionun metni
                                                Value = x.WriterId.ToString()    //optionun valuesi
                                            }).ToList();
            ViewBag.writers = writers;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading newHeading)
        {
            HeadingValidator hv = new HeadingValidator();
            ValidationResult results = hv.Validate(newHeading);

            if (results.IsValid)
            {
                newHeading.HeadingDate = DateTime.Now;
                hm.AddHeadingBl(newHeading);
                return RedirectToAction("Index");
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
            hm.UpdateHeadingBl(heading);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingByCategory(int id)
        {
            var contents = hm.GetListtByCategoryId(id);
            return View(contents);
        }
        public ActionResult HeadingByWriter(int id)
        {
            var contents = hm.GetListtByWriterId(id);
            return View(contents);
        }
        public ActionResult DeleteHeadingMain(int id)
        {
            var heading = hm.GetByID(id);
            hm.DeleteHeadingMainBl(heading);
            TempData["messagedelete"] = "Əməliyyat uğurla icra edildi.Seçmiş olduğunuz başlıq qalıcı olaraq silindi.";
            return RedirectToAction("Index");
        }
    }
}