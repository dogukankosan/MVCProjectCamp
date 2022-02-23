using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("YAZARIN ADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("YAZARIN SOYADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("YAZARIN RESİM BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("YAZARIN MAİLİ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("YAZARIN ŞİFRESİ BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("YAZARIN ADI 30 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.WriterSurName).MaximumLength(30).WithMessage("YAZARIN SOYADI 30 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Image).MaximumLength(250).WithMessage("YAZARIN RESİM 250 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("YAZARIN MAİLİ 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.Password).MaximumLength(30).WithMessage("YAZARIN ŞİFRESİ 30 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.WriterAbout).MaximumLength(150).WithMessage("YAZARIN HAKKINDA BİLGİ 150 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("YAZARIN HAKKINDA BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("YAZARIN UNVANI 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("YAZARIN UNVANI BOŞ GEÇİLEMEZ !!");
        }
    }
}
