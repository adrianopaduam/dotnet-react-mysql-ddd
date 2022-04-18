using FluentValidation;
using ProductSeller.Domain.Entities;

namespace ProductSeller.Service.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Value).NotEmpty().NotNull();
        }
    }
}