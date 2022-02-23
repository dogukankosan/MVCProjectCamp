using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class HeadingValidation : AbstractValidator<Heading>
    {
        public HeadingValidation()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("BAŞLIK ADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("BAŞLIK ADI 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("KATEGORİ ADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.WriterID).NotEmpty().WithMessage("YAZAR ADI BOŞ GEÇİLEMEZ !!");
        }
    }
}
