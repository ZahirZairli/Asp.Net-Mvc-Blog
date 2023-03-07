using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.RecieverMail).NotEmpty().WithMessage("Zəhmət olmasa maili qeyd edin");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Zəhmət olmasa mesajın başlığını qeyd edin");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Zəhmət olmasa mövzunu qeyd edin");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            RuleFor(x => x.MessageContent).MinimumLength(3).WithMessage("Zəhmət olmasa ən azı 3 simvol daxil edin");
            //RuleFor(x => x.MessageContent).MaximumLength(200).WithMessage("Zəhmət olmasa ən çoxu 200 simvol daxil edin");
            RuleFor(x => x.RecieverMail).EmailAddress().WithMessage("Zəhmət olmasa keçərli bir mail adresi daxil edin");
        }
    }
}
