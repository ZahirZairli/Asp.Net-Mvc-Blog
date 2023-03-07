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
    public class WriterPanelContentController : Controller
    {
    ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            int id;
            string p;
            p = (string)Session["WriterMail"];
            var writer = wm.GetByMailSession(p);
            id = writer.WriterId;
            var contents = cm.GetListtByWriterId(id);
            return View(contents);
        }

        [HttpGet]
        public ActionResult NewContent(int id)
        {
            ViewBag.headingid = id;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)] //SummerNote
        public ActionResult NewContent(Content content)
        {
            content.ContentDate = DateTime.Now;
            content.WriterId = (int)Session["WriterId"];
            cm.ContentAddBl(content);
            return RedirectToAction("MyContent");
        }
    }
}