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
    public class CategoryManager : ICategoryService
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBl(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<CategoryChart> GetChart()
        {
            List<CategoryChart> categoryChart = new List<CategoryChart>();
            //var list = headings.GroupBy(e=>e.CategoryId).Select(x => new CategoryChart {NameId = x.Key,Count = x.Count() }).ToList();
            var headings = hm.GetListActive();
            List<CategoryChart> categories = (from x in headings.GroupBy(e => e.CategoryId)
                                              select new CategoryChart
                                              {
                                                  Name = Convert.ToString(x.Key),   //optionun metni
                                                  Count = x.Count(), //optionun valuesi
                                              }).ToList();
            foreach (var item in categories)
            {
                var catid = Convert.ToInt32(item.Name);
                var category = _categoryDal.Get(x=>x.CategoryId == catid); 
                categoryChart.Add(new CategoryChart()
                {
                    Name =  category.CategoryName,
                    Count = item.Count,
                });
            }
            return categoryChart;
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
        public List<Category> GetListActive()
        {
            return _categoryDal.List(x=>x.CategoryStatus == true);
        }
    }
}
