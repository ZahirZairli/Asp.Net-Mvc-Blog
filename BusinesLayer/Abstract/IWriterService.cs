using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAddBl(Writer writer);
        Writer GetByID(int id);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetByMail(string mail, string pass);
        Writer GetByMailSession(string mail);
    }
}
