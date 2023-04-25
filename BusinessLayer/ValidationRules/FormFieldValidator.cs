using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class FormFieldValidator : AbstractValidator<FormField>
    {
        public FormFieldValidator()
        {
            RuleFor(x => x.ColumnName).NotEmpty().WithMessage("Adı Boş Geçilemez");
            RuleFor(x => x.ColumnName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz");
            RuleFor(x => x.ColumnName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
        }
    }
}
