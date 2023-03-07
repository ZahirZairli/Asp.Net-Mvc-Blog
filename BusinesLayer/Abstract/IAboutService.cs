using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IAboutService
    {
        void AddAboutBl(About about);
        void DeleteAboutBl(About about);
        List<About> GetList();
        List<About> GetActiveList();
        About GetById(int id);
        void AboutUpdate(About about);
    }
}
