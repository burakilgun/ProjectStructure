using FluentValidation;
using Nairobi.Application.Commands;

namespace Nairobi.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori alanı zorunludur.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı alanı zorunludur.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün açıklama alanı zorunludur.");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyat alanı zorunludur.");
            RuleFor(p => p.Price).NotNull().GreaterThan(0).WithMessage("Lütfen geçerli fiyat giriniz");
            RuleFor(p => p.CategoryId).Length(24).WithMessage("Kategori id geçersiz.");
        }
    }
}
