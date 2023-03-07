using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    public class WriterController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Writer
        public ActionResult Index(int page = 1)
        {
            var writerValues = wm.GetList().ToPagedList(page, 6);
            return View(writerValues);
        }
        public ActionResult DeleteWriter(int id)
        {
            var writer = wm.GetByID(id);
            wm.WriterDelete(writer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p, HttpPostedFileBase WriterImage)
        {
            var writer = wm.GetByMailSession(p.WriterMail);
            var admin = am.GetAdminByMail(p.WriterMail);

            if (writer == null && admin == null)
            {
                WriterValidator wv = new WriterValidator();
                ValidationResult results = wv.Validate(p);
                if (results.IsValid)
                {
                    if (WriterImage != null)
                    {
                        string PhotoName = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(WriterImage.FileName);
                        WriterImage.SaveAs(Server.MapPath("~/Content/images/" + PhotoName));
                        p.WriterImage = PhotoName;
                    }
                    else
                    {
                        p.WriterImage = "avatar.png";
                    }
                    wm.WriterAddBl(p);
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
            else
            {
                TempData["AddAdminError"] = "BU maildə sistemdə admin və ya istifadəçi mövcuddur.Zəhmət olmasa başqa maildən istifadə edin";
                return View();
            }


        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writer = wm.GetByID(id);
            return View(writer);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer, HttpPostedFileBase WriterImage)
        {
            if (WriterImage != null)
            {
                string PhotoName = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(WriterImage.FileName);
                WriterImage.SaveAs(Server.MapPath("~/Content/images/" + PhotoName));
                writer.WriterImage = PhotoName;
            }
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}