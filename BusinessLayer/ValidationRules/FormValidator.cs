using EntityLayer.Concrete;
using FluentValidation;
namespace BusinessLayer.ValidationRules
{
    public class FormValidator:AbstractValidator<Form>
    {
        public FormValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Form Adı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Form Açıklaması Boş Geçilemez");
            RuleFor(x => x.Description).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
        }
    }
}
