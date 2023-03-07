using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IMessageService
    {
        void AddMessageBl(Message message);
        void DeleteMessageBl(Message message);
        void DeleteMessageAll(Message message);

        List<Message> GetListInbox(string mail);
        List<Message> GetListInboxReaded(string mail);
        List<Message> GetListInboxNotReaded(string mail);
        List<Message> GetListDeleted(string mail);
        List<Message> GetDraftsList(string mail);
        List<Message> GetListSending(string mail);
        
        Message GetById(int id);
        Message GetByIdTr(int id);
        Message GetByIdDraft(int id);
        void MessageUpdate(Message message);
    }
}
