using BusinesLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DtoChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeadingBl(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void DeleteHeadingBl(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void DeleteHeadingMainBl(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<HeadingChart> GetChart()
        {
            List<HeadingChart> headingChart = new List<HeadingChart>();
            //var list = headings.GroupBy(e=>e.CategoryId).Select(x => new CategoryChart {NameId = x.Key,Count = x.Count() }).ToList();
            var contents = cm.GetList();
            List<HeadingChart> headings= (from x in contents.GroupBy(e => e.HeadingId)
                                              select new HeadingChart
                                              {
                                                  Name = Convert.ToString(x.Key),   //optionun metni
                                                  Count = x.Count(), //optionun valuesi
                                              }).ToList();
            foreach (var item in headings)
            {
                var catid = Convert.ToInt32(item.Name);
                var heading = _headingDal.Get(x => x.HeadingId == catid);
                headingChart.Add(new HeadingChart()
                {
                    Name = heading.HeadingName,
                    Count = item.Count,
                });
            }
            return headingChart;
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListActive()
        {
            return _headingDal.List(x => x.HeadingStatus == true);
        }

        public List<Heading> GetListtByCategoryId(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }
        public List<Heading> GetListtByWriterId(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public void RestoreHeadingBl(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void UpdateHeadingBl(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
