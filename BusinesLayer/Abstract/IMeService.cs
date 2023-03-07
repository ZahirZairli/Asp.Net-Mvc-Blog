using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IMeService
    {
        List<Me> GetList();
        Me GetBy();
        void MeUpdate(Me me);
    }
}
