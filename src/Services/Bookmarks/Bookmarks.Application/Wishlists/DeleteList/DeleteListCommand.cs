using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Bookmarks.Application.Wishlists.DeleteList;

public sealed class DeleteListCommand
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
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IWishlistRepository wishlistRepository, IUnitOfWork unitOfWork)
        {
            _wishlistRepository = wishlistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await DeleteList(request.Id, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted empty wishlist {request.Id}")
                : Result<string>.Failure($"Failed to delete wishlist {request.Id}: not found or not empty!");
        }

        private async Task<bool> DeleteList(Guid id, CancellationToken cancellationToken)
        {
            await _wishlistRepository
                .DeleteList(id)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}