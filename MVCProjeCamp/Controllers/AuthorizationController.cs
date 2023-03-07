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
    [Authorize(Roles = "A")]
    public class AuthorizationController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var admins = am.GetList();
            return View(admins);
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            var admins = am.GetAdminByMail(admin.AdminMail);
            var writers = wm.GetByMailSession(admin.AdminMail);

            if (admins == null && writers == null)
            {
                am.AdminAdd(admin);
                TempData["AddAdmin"] = "Yeni admin sistemə uğurla əlavə edildi.";
            }
            else
            {
                TempData["AddAdminError"] = "BU maildə sistemdə admin və ya istifadəçi mövcuddur.Zəhmət olmasa başqa maildən istifadə edin";
            }
                return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            int adminId =(int)Session["AdminId"];
            if (adminId != id)
            {
                var admin = am.GetAdminById(id);
                am.AdminDelete(admin);
                TempData["DeleteAdmin"] = "Seçilmiş admin sistemdən uğurla silindi.";
            }
            else
            {
                TempData["DeleteAdminError"] = "Öz hesabınızı silə bilməzsiniz!";
            }
            return RedirectToAction("Index");
        }
    }
}