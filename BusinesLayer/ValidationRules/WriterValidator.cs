using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Zəhmət olmasa adı boş buraxmayın");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Zəhmət olmasa soy adı boş buraxmayın");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Zəhmət olmasa maili boş buraxmayın");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Zəhmət olmasa parolu boş buraxmayın");
            //RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Zəhmət olmasa haqqınızda hissəsini boş buraxmayın");
            //RuleFor(x => x.WriterPhone).NotEmpty().WithMessage("Zəhmət olmasa telefon nömrəsi daxil edin");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Zəhmət olmasa ən çoxu 20 simvol daxil edin");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Zəhmət olmasa ən çoxu 20 simvol daxil edin");
            RuleFor(x => x.WriterPassword).Must(PasswordContain).WithMessage("Şifrəniz ən azı bir böyük,bir balaca və bir rəqəmdən ibarət olmalıdır!(Qeyd: şifrədə böyük Azərbaycan şriftlərindən istifadə etməyin!) ");
        }
        private bool PasswordContain(string zahir)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(zahir);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
