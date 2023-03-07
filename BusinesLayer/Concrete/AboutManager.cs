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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public void AddAboutBl(About about)
        {
            _aboutDal.Insert(about);
        }

        public void DeleteAboutBl(About about)
        {
            _aboutDal.Delete(about);
        }

        public List<About> GetActiveList()
        {
            return _aboutDal.List(x=>x.AboutStatus == true);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }
}
