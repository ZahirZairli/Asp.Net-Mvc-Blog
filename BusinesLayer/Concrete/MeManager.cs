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
    public class MeManager : IMeService
    {
        IMeDal _meDal;

        public MeManager(IMeDal meDal)
        {
            _meDal = meDal;
        }

        public Me GetBy()
        {
            return _meDal.List().FirstOrDefault();
        }

        public List<Me> GetList()
        {
            return _meDal.List();
        }

        public void MeUpdate(Me me)
        {
            _meDal.Update(me);
        }
    }
}
