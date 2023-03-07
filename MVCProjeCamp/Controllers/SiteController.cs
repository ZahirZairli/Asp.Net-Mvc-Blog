using BusinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        AboutManager am = new AboutManager(new EfAboutDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Site
        public ActionResult HeadingAll(int? id,string p)
        {
            if (id != null & !string.IsNullOrEmpty(p))
            {
                var contents2 = cm.GetListByText(p);
                ViewBag.name = p + ' ' + "üzrə axtarışın nəticəsi";
                return View(contents2);
            }
            else if (id == null & !string.IsNullOrEmpty(p))
            {
                var contents2 = cm.GetListByText(p);
                ViewBag.name = p + ' ' + "üzrə axtarışın nəticəsi";
                return View(contents2);
            }
            else if (id !=null & string.IsNullOrEmpty(p))
            {
                int id2 = Convert.ToInt32(id);
                var values = cm.GetListtByHeadingId(id2);
                ViewBag.name = hm.GetByID(id2).HeadingName;
                return View(values);

            }
            else 
            {
                var articles = cm.GetList().OrderByDescending(a => a.ContentDate).ThenBy(a => a.ContentId).Take(5).ToList();
                ViewBag.name = "Ən son yazılan 5 yazı";
                return View(articles);
            }
        }
        public PartialViewResult Headings()
        {
            var headings = hm.GetListActive();
            return PartialView(headings);
        }
        public ActionResult ContentByWriter(int id)
        {
            var contents = cm.GetListtByWriterId(id);
            return View(contents);
        }
        public ActionResult AboutUs()
        {
            var about = am.GetActiveList();
            return View(about);
        }
    }
}