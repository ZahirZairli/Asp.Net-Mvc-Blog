using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MVCProjeCamp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeCamp.Controllers
{
    [AllowAnonymous]
    public class WriterPanelLoginController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        // GET: WriterPanelLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Writer p)
        {
            //var response = Request["g-recaptcha-response"];
            //const string secret = "6LeJyGUkAAAAAPj7DfBPQLApsjTSiaJoiU9ik3dv";
            ////Kendi Secret keyinizle değiştirin.

            //var client = new WebClient();
            //var reply =
            //    client.DownloadString(
            //        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            //var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //if (!captchaResponse.Success)
            //{

            //    TempData["Message"] = "Zəhmət olmasa təhlükəsizliyi doğrulayın!";
            //    return View();
            //}


            var writer = wm.GetByMail(p.WriterMail, p.WriterPassword);

                if (writer != null)
                {
                    FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                    Session["WriterMail"] = writer.WriterMail;
                    Session["WriterId"] = writer.WriterId;
                    Session["WriterImage"] = writer.WriterImage;
                    Session["FullName"] = writer.WriterName + ' ' + writer.WriterSurname;
                    return RedirectToAction("Index", "WriterPanelMessage/Inbox");
                }
                else
                {
                    TempData["Message"] = "Hesabınıza giriş edilmədi.Zəhmət olmasa məlumatların düzgünlüyünü yoxlayın";
                    return View();
                }
            

        }

        [HttpGet]
        public ActionResult WriterSignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterSignUp(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);

            var writer = wm.GetByMailSession(p.WriterMail);
            var admin = am.GetAdminByMail(p.WriterMail);
            if (writer == null && admin== null)
            {
                if (results.IsValid)
                {
                    p.WriterImage = "avatar.png";
                    wm.WriterAddBl(p);
                    TempData["SignUpWriterSuc"] = "Uğurla qeydiyyatdan keçildi";
                    return RedirectToAction("Login");
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
                TempData["SignUpWriterError"] = "BU maildə sistemdə admin və ya istifadəçi mövcuddur.Zəhmət olmasa başqa maildən istifadə edin";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HeadingAll", "Site");
        }
    }
}