using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class GalleryValidation : AbstractValidator<Gallery>
    {
        public GalleryValidation()
        {
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("RESİM ADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("RESİM YOLU BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.ImageName).MaximumLength(100).WithMessage("RESİM ADI 100 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.ImagePath).MaximumLength(350).WithMessage("RESİM YOLU 350 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}
