using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class ContentValidation : AbstractValidator<Content>
    {
        public ContentValidation()
        {
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("YORUM İÇERİĞİ BOŞ GEÇİLEMEZ !!");
        }
    }
}
