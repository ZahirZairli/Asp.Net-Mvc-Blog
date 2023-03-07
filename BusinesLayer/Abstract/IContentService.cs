using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByText(string p);
        List<Content> GetListtByHeadingId(int id);
        List<Content> GetListtByWriterId(int id);
        void ContentAddBl(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
