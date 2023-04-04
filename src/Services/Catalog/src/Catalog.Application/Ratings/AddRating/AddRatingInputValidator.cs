using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Catalog.Application.Ratings.AddRating
{
    internal class AddRatingInputValidator : AbstractValidator<AddRatingInput>
    {
        public AddRatingInputValidator()
        {
            RuleFor(e => e.ProductId).NotEmpty();
            RuleFor(e => e.Value).NotEmpty().InclusiveBetween(1, 5);
        }
    }
}
