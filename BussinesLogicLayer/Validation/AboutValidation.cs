using EntitiyLayer.Concrete;
using FluentValidation;

namespace BussinesLogicLayer.Validation
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("HAKKINDA 1. KISMINI BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("HAKKINDA 2. KISMINI BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.AboutImage1).NotEmpty().WithMessage("RESİM 1. KISMINI BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.AboutImage2).NotEmpty().WithMessage("RESİM 2. KISMINI BOŞ GEÇEMEZSİNİZ !!");
            RuleFor(x => x.AboutDetails1).MaximumLength(250).WithMessage("HAKKINDA 1. KISMININ 250 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.AboutDetails2).MaximumLength(250).WithMessage("HAKKINDA 2. KISMININ 250 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.AboutImage1).MaximumLength(150).WithMessage("RESİM 1. KISMININ 150 KARAKTERDEN FAZLA OLAMAZ !!");
            RuleFor(x => x.AboutImage2).MaximumLength(150).WithMessage("RESİM 2. KISMININ 150 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}
