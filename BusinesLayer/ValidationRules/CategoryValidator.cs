using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Zəhmət olmasa kateqoriya adını boş buraxmayın");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Zəhmət olmasa kateqoriya təsvirini boş buraxmayın");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Zəhmət olmasa ən çoxu 20 simvol daxil edin");
        }
    }
}
