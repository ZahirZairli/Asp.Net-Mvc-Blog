using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Zəhmət olmasa mailinizi qeyd edin");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Zəhmət olmasa istifadəçi adınızı qeyd edin");
            RuleFor(x => x.UserSubject).NotEmpty().WithMessage("Zəhmət olmasa mövzunu qeyd edin");
            RuleFor(x => x.UserSubject).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            RuleFor(x => x.UserSubject).MaximumLength(50).WithMessage("Zəhmət olmasa ən çoxu 50 simvol daxil edin");
        }
    }
}
