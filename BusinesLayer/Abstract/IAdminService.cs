using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetByMail(string mail,string pass);
        Admin GetAdminByMail(string mail);
        Admin GetAdminById(int id);
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
