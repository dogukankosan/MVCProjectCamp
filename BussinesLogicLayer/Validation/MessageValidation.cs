using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class MessageValidation : AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("MESAJ KONU BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.ContextText).NotEmpty().WithMessage("MESAJ İÇERİĞİ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("ALICI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Sender).NotEmpty().WithMessage("GÖNDERİCİ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Receiver).Must(x => x.Contains("@")).WithMessage("MAİL ADRESİNİZ GEÇERLİ DEĞİLDİR !!");
            RuleFor(x => x.Subject).MaximumLength(70).WithMessage("MESAJ KONU 70 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Receiver).MaximumLength(70).WithMessage("ALICI 70 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Sender).MaximumLength(70).WithMessage("GÖNDERİCİ 70 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}
