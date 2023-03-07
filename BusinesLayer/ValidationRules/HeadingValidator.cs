using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            //RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Zəhmət olmasa başlığın adını qeyd edin");
            //RuleFor(x => x.HeadingName).MinimumLength(8).WithMessage("Zəhmət olmasa ən azı 8 simvol qeyd edin");
            //RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Zəhmət olmasa 50 simvoldan artıq qeyd etməyin");
            //RuleFor(x => x.WriterId).NotEmpty().WithMessage("Zəhmət olmasa bir yazıçı seçin");
            //RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Zəhmət olmasa bir kateqoriya seçin");
        }
    }
}
