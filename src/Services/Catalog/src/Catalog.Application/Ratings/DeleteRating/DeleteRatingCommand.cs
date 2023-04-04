using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using MediatR;
using Catalog.Domain.Ratings;
using FluentValidation.Results;

namespace Catalog.Application.Ratings.DeleteRating;

public sealed class DeleteRatingCommand
{
    public class Command : IRequest<Result<string>>
    {
        public Command(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public class Handler : IRequestHandler<Command, Result<string>>
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

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            string? userId = _userService.GetCurrentUserId();
            if (userId == null)
            {
                return Result<string>.Failure("Not authenticated!");
            }

            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            Rating? rating = await _ratingRepository.GetRatingById(request.Id).ConfigureAwait(false);
            if (rating != null && rating.UserId != new Guid(userId))
            {
                return Result<string>.Failure("Access denied");
            }

            bool success = await DeleteRating(request.Id, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted rating {request.Id}")
                : Result<string>.Failure($"Failed to delete rating {request.Id}");
        }

        private async Task<bool> DeleteRating(Guid id, CancellationToken cancellationToken)
        {
            await _ratingRepository
                .DeleteRating(id)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}