using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class AdminValidation : AbstractValidator<Admin>
    {
        public AdminValidation()
        {
            RuleFor(x => x.UserNameAdmin).NotEmpty().WithMessage("KULLANICI ADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.PasswordAdmin).NotEmpty().WithMessage("ŞİFRESİ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("ROLÜ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.UserNameAdmin).MaximumLength(50).WithMessage("KULLANICI ADI 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.PasswordAdmin).MaximumLength(50).WithMessage("ŞİFRESİ 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.AdminRole).MaximumLength(1).WithMessage("ROLÜ 1 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("RESİM BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Image).MaximumLength(200).WithMessage("RESİM 200 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("MAİL ADRESİNİZİ BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.Mail).MaximumLength(75).WithMessage("MAİL ADRESİNİZ 75 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}
