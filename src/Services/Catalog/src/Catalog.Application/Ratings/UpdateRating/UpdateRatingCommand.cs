using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using MediatR;
using Catalog.Domain.Ratings;
using FluentValidation.Results;

namespace Catalog.Application.Ratings.UpdateRating;

public sealed class UpdateRatingCommand
{
    public class Command : IRequest<Result<RatingDto>>
    {
        public Command(UpdateRatingInput input)
        {
            Input = input;
        }

        public UpdateRatingInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateRatingInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IRatingRepository ratingRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
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

            Rating? rating = await _ratingRepository.GetRatingById(request.Input.Id);
            if (rating == null)
            {
                return Result<RatingDto>.Failure($"Rating with ID {request.Input.Id} not found");
            }

            if (rating.UserId != new Guid(userId))
            {
                return Result<RatingDto>.Failure("Access denied");
            }

            bool success = await UpdateRating(request.Input.Id, request.Input.Value, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<RatingDto>.Success(new RatingDto(rating))
                : Result<RatingDto>.Failure($"Failed to update rating {request.Input.Id}");
        }

        private async Task<bool> UpdateRating(Guid id, int newValue, CancellationToken cancellationToken)
        {
            await _ratingRepository
                .UpdateRating(id, newValue)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}