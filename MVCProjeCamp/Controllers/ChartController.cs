using BusinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MVCProjeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [Authorize(Roles = "A,B")]
    public class ChartController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: Chart
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult Heading()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(cm.GetChart(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult HeadingChart()
        {
            return Json(hm.GetChart(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReportsCategory()
        {
            var values = cm.GetChart();
            return View(values);
        }
        public ActionResult ReportsHeading()
        {
            var values = hm.GetChart();
            return View(values);
        }
        //public ActionResult ContentChart()
        //{
        //    return Json(ContentManager.GetChart(), JsonRequestBehavior.AllowGet);
        //}
    }
}