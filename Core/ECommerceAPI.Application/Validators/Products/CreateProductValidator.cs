using FluentValidation;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator 
    {
        public CreateProductValidator()
        {
            //RuleFor(p => p.Name)
            //    .NotEmpty()
            //    .NotNull()
            //        .WithMessage("Please fill the name")
            //    .MaximumLength(150)
            //    .MinimumLength(4)
            //        .WithMessage("Character below 150 more than 4");

            //RuleFor(p => p.Stock)
            //    .NotEmpty()
            //    .NotNull()
            //        .WithMessage("Plesae fill the stock")
            //    .Must(s => s >= 0)
            //        .WithMessage("Stock can't be negative");

            //RuleFor(p => p.Price)
            //    .NotEmpty()
            //    .NotNull()
            //        .WithMessage("Plesae fill the price")
            //    .Must(s => s >= 0)
            //        .WithMessage("Price can't be negative");
        }
    }
}
