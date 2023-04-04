using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Domain.Ratings;
using FluentValidation.Results;

namespace Catalog.Application.Ratings.AddRating
{
    public sealed class AddRatingCommand
    {
        public class Command : IRequest<Result<RatingDto>>
        {
            public Command(AddRatingInput input)
            {
                Input = input;
            }

            public AddRatingInput Input { get; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Input).SetValidator(new AddRatingInputValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<RatingDto>>
        {
            private readonly IEntityFactory _entityFactory;
            private readonly IRatingRepository _ratingRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IUserService _userService;

            public Handler(IEntityFactory entityFactory, IRatingRepository ratingRepository, IUnitOfWork unitOfWork,
                IUserService userService)
            {
                _entityFactory = entityFactory;
                _ratingRepository = ratingRepository;
                _unitOfWork = unitOfWork;
                _userService = userService;
            }

            public async Task<Result<RatingDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                string? userId = _userService.GetCurrentUserId();
                if (userId == null)
                {
                    return Result<RatingDto>.Failure("Not authenticated!");
                }

                CommandValidator validator = new CommandValidator();
                ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    return Result<RatingDto>.Failure($"{string.Join('\n', validation.Errors)}");
                }

                Rating rating =
                    _entityFactory.NewRating(new Guid(userId), request.Input.ProductId, request.Input.Value);

                bool success = await AddRating(rating, cancellationToken)
                    .ConfigureAwait(false);

                return success
                    ? Result<RatingDto>.Success(new RatingDto(rating))
                    : Result<RatingDto>.Failure("Failed to create a rating or already rated");
            }

            private async Task<bool> AddRating(Rating rating, CancellationToken cancellationToken)
            {
                await _ratingRepository
                    .AddRating(rating)
                    .ConfigureAwait(false);

                var changes = await _unitOfWork
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return changes > 0;
            }
        }
    }
}
