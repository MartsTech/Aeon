﻿using FluentValidation;

namespace Catalog.Application.Products.UpdateProduct
{
    internal class UpdateProductInputValidator : AbstractValidator<UpdateProductInput>
    {
        public UpdateProductInputValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(90);
            RuleFor(x => x.Description).MaximumLength(255);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Discount).GreaterThan(0);
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryName).NotEmpty();
        }
    }
}
