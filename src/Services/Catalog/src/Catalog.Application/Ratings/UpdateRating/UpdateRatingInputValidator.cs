using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Catalog.Application.Ratings.UpdateRating
{
    internal class UpdateRatingInputValidator : AbstractValidator<UpdateRatingInput>
    {
        public UpdateRatingInputValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
            RuleFor(e => e.Value).NotEmpty().InclusiveBetween(1, 5);
        }
    }
}
