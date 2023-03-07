using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [Authorize(Roles = "A,B")]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            var contacts = cm.GetList();
            return View(contacts);
        }
        public ActionResult MessageDetail(int id)
        {
            var message = cm.GetByID(id);
            return View(message);
        }
        public PartialViewResult ContactGeneralPartial()
        {
            string mail;
            mail = (string)Session["AdminMail"];
            ViewBag.countContact = cm.GetList().Count;
            ViewBag.countTrash= mm.GetListDeleted(mail).Count;
            ViewBag.countInbox = mm.GetListInbox(mail).Count;
            ViewBag.countNotReaded = mm.GetListInboxNotReaded(mail).Count;
            ViewBag.countReaded = mm.GetListInboxReaded(mail).Count;
            ViewBag.countSending= mm.GetListSending(mail).Count;
            ViewBag.countDrafts= mm.GetDraftsList(mail).Count;
            return PartialView();
        }
        public ActionResult DeleteContact(int id)
        {
            var contact = cm.GetByID(id);
            cm.ContactDelete(contact);
            return RedirectToAction("Index");
        }
    }
}