using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İSMİNİZİ BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("MESAJ İÇERİĞİNİ BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("MAİL ADRESİNİZİ BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("MESAJ KONUSU BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("İSMİNİZ 30 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("MAİL ADRESİNİZ 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("MESAJ KONUSUSU 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.ContentText).MaximumLength(250).WithMessage("MESAJ İÇERİĞİ 250 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}