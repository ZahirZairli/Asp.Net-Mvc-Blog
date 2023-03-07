using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    public class WriterPanelProfileController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelProfile
        public ActionResult MyProfile()
        {
            string p;
            p = (string)Session["WriterMail"];
            var writer = wm.GetByMailSession(p);
            return View(writer);
        }
        [HttpPost]
        public ActionResult MyProfile(Writer writer, HttpPostedFileBase WriterImage)
        {
            if (WriterImage != null)
            {
                string PhotoName = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(WriterImage.FileName);
                WriterImage.SaveAs(Server.MapPath("~/Content/images/" + PhotoName));
                writer.WriterImage = PhotoName;
            }
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            string p;
            p = (string)Session["WriterMail"];
            int id;
            id = (int)Session["WriterId"];
            writer.WriterId = id;
            writer.WriterMail = p;
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("MyProfile");
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