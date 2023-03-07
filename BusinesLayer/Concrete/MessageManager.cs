using BusinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public void AddMessageBl(Message message)
        {
            _messageDal.Insert(message);
        }

        public void DeleteMessageBl(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDal.List(x=>x.RecieverMail == mail & x.DraftStatus == false & x.MessageStatus == true);
        }
        public List<Message> GetListSending(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail &x.DraftStatus == false & x.MessageStatus == true);
        }

        public List<Message> GetDraftsList(string mail)
        {
            return _messageDal.List(x => x.DraftStatus == true & x.SenderMail == mail & x.MessageStatus == true);
        }

        public Message GetByIdDraft(int id)
        {
            return _messageDal.Get(x => x.MessageId == id & x.DraftStatus == true);
        }

        public List<Message> GetListDeleted(string mail)
        {
            return _messageDal.List(x => x.MessageStatus == false & x.DraftStatus == false & x.SenderMail == mail);
        }

        public Message GetByIdTr(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void DeleteMessageAll(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetListInboxReaded(string mail)
        {
            return _messageDal.List(x => x.RecieverMail == mail & x.DraftStatus == false & x.MessageStatus == true & x.ReadingStatus == true);
        }

        public List<Message> GetListInboxNotReaded(string mail)
        {
            return _messageDal.List(x => x.RecieverMail == mail & x.DraftStatus == false & x.MessageStatus == true & x.ReadingStatus == false);
        }
    }
}
