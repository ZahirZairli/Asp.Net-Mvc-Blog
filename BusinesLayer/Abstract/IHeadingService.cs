using EntityLayer.Concrete;
using EntityLayer.DtoChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IHeadingService
    {
        List<HeadingChart> GetChart();
        List<Heading> GetList();
        List<Heading> GetListActive();
        Heading GetByID(int id);
        void AddHeadingBl(Heading heading);
        void DeleteHeadingBl(Heading heading);
        void DeleteHeadingMainBl(Heading heading);
        void RestoreHeadingBl(Heading heading);
        void UpdateHeadingBl(Heading heading);
        List<Heading> GetListtByCategoryId(int id);
        List<Heading> GetListtByWriterId(int id);
    }
}
