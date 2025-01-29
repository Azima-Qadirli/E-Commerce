using FluentValidation;
using MiniE_Commerce.Application.ViewModels.Products;

namespace MiniE_Commerce.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Zəhmət olmasa məhsulun adını daxil edin")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Məhsulun adı minimum 5, maksimum 150 simvoldan ibarət olmalıdır");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Zəhmət olmasa məhsulun sayını daxil edin")
                .Must(s => s >= 0)
                .WithMessage("Məhsulun sayı 0-dan yuxarı olmalıdır");

            RuleFor(p => p.Price)
               .NotEmpty()
               .NotNull()
               .WithMessage("Zəhmət olmasa qiyməti  daxil edin")
               .Must(s => s >= 0)
               .WithMessage("Məhsulun qiyməti 0-dan yuxarı olmalıdır");
        }
    }
}
