using FluentValidation;
using Nairobi.Application.Requests;

namespace Nairobi.Validators
{
    public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Ürün id boş bırakılamaz.");
            RuleFor(p => p.Id).Length(24).WithMessage("Ürün id geçersiz.");
        }
    }
}
