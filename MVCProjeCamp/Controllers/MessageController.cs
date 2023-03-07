﻿using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeCamp.Controllers
{
    [Authorize(Roles = "A,B")]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        // GET: Message
        public ActionResult Inbox(int? id)
        {
            string mail;
            mail = (string)Session["AdminMail"];
            if (id==1)
            {
                  var messages1 = mm.GetListInboxNotReaded(mail);
                ViewBag.Info = "Oxunmamış mesajlar";
                return View(messages1);
            }
            else if (id == 2)
            {
                var messages2 = mm.GetListInboxReaded(mail);
                ViewBag.Info = "Oxunmuş mesajlar";
                return View(messages2);
            }
            else
            {
                    var messages3 = mm.GetListInbox(mail);
                     ViewBag.Info = "Gələn mesajlar";
                    return View(messages3);
            }
        }
        public ActionResult MessageDetail(int id)
        {
            var message = mm.GetById(id);

            if (message.ReadingStatus == false)
            {
                message.ReadingStatus = true;
                mm.MessageUpdate(message);
            }
            return View(message);
        }
        public ActionResult Sending()
        {
            string mail;
            mail = (string)Session["AdminMail"];
            var messages = mm.GetListSending(mail);
            return View(messages);
        }
        public ActionResult SendingDetail(int id)
        {
            var message = mm.GetById(id);
            return View(message);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)] //SummerNote
        public ActionResult NewMessage(Message newMessage, string submit)
        {
            MessageValidator mv = new MessageValidator();
            ValidationResult results = mv.Validate(newMessage);
            string mail;
            mail = (string)Session["AdminMail"];
            if (results.IsValid)
            {
                switch (submit)
                {
                    case "Draft":
                        newMessage.DraftStatus = true;
                        break;
                    case "Save":
                        newMessage.DraftStatus = false;
                        break;
                }
                newMessage.SenderMail = mail;
                mm.AddMessageBl(newMessage);
                return RedirectToAction("Sending");
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
        public ActionResult Drafts()
        {
            string mail;
            mail = (string)Session["AdminMail"];
            var messages = mm.GetDraftsList(mail);
            return View(messages);
        }

        [HttpGet]
        public ActionResult DraftDetail(int id)
        {
            var message = mm.GetByIdDraft(id);
            return View(message);
        }
        [HttpPost]
        [ValidateInput(false)] //bu tanım
        public ActionResult DraftDetail(Message message)
        {
            MessageValidator mv = new MessageValidator();
            ValidationResult results = mv.Validate(message);

            if (results.IsValid)
            {
                message.MessageDate = DateTime.Now;
                message.MessageContent.ToString().TrimStart();
                message.DraftStatus = false;
                mm.MessageUpdate(message);
                return RedirectToAction("Sending");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
                var id = message.MessageId;
            var messageold = mm.GetById(id);
            return View(messageold);
        }
        public ActionResult Trash()
        {
            string mail;
            mail = (string)Session["AdminMail"];
            var messages = mm.GetListDeleted(mail);
            return View(messages);
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = mm.GetById(id);
            message.MessageStatus= false;
            mm.DeleteMessageBl(message);
            return RedirectToAction("Inbox");
        }
        public ActionResult RecoverMessage(int id)
        {
            var message = mm.GetByIdTr(id);
            message.MessageStatus = true;
            mm.DeleteMessageBl(message);
            return RedirectToAction("Trash");
        }
        public ActionResult DeleteMessageAll(int id)
        {
            var message = mm.GetByIdTr(id);
            mm.DeleteMessageAll(message);
            return RedirectToAction("Trash");
        }
    }
}