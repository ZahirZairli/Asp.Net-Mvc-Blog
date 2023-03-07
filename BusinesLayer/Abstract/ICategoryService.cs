using BusinesLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DtoChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        List<Category> GetListActive();
        List<CategoryChart> GetChart();
        void CategoryAddBl(Category category);
        Category GetByID(int id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
