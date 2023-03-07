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
    public class MeController : Controller
    {
        MeManager mm = new MeManager(new EfMeDal());
        // GET: Me
        public ActionResult Me()
        {
            var me = mm.GetList();
            return View(me);
        }
        public ActionResult EditMe()
        {
            var me = mm.GetBy();
            return View(me);
        }
        [HttpPost]
        public ActionResult EditMe(Me me)
        {
            mm.MeUpdate(me);
            return RedirectToAction("Me");
        }
    }
}