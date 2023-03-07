using BusinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [Authorize(Roles = "A,B")]
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contents = cm.GetListtByHeadingId(id);
            return View(contents);
        }
        public ActionResult ContentByWriter(int id)
        {
            var contents = cm.GetListtByWriterId(id);
            return View(contents);
        }
        public ActionResult AllContent(string p)
        {

            if (!string.IsNullOrEmpty(p))
            {
                var contents1 = cm.GetListByText(p);
                    return View(contents1);
            }
            else
            {
                var contents2 = cm.GetList();
                return View(contents2);
            }
        }
    }
}