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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetAdminById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetAdminByMail(string mail)
        {
            return _adminDal.Get(x => x.AdminMail == mail);
        }

        public Admin GetByMail(string mail,string pass)
        {
            return _adminDal.Get(x => x.AdminMail == mail && x.AdminPassword == pass);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
