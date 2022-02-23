using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("KATEGORİ ADI BOŞ GEÇİLEMEZ !!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("KATEGORİ ADI 50 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.CategoryDescription).MaximumLength(250).WithMessage("KATEGORİ AÇIKLAMASI 250 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}
