using BusinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var admin = am.GetByMail(p.AdminMail,p.AdminPassword);

            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminMail,false);
                Session["AdminMail"] = admin.AdminMail;
                Session["AdminId"] = admin.AdminId;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                TempData["Message"] = "Hesabınıza giriş edilmədi.Zəhmət olmasa məlumatların düzgünlüyünü yoxlayın";
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