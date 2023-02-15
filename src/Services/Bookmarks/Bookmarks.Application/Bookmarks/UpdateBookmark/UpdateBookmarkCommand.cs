using Bookmarks.Domain;
using Bookmarks.Domain.Bookmarks;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Bookmarks.Application.Bookmarks.UpdateBookmark;

public sealed class UpdateBookmarkCommand
{
    public class Command : IRequest<Result<bool>>
    {
        public Command(UpdateBookmarkInput input)
        {
            Input = input;
        }

        public UpdateBookmarkInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateBookmarkInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<bool>>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IEntityFactory entityFactory, IBookmarkRepository bookmarkRepository, IUnitOfWork unitOfWork)
        {
            _bookmarkRepository = bookmarkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<bool>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await UpdateQuantity(request.Input.Id, request.Input.Quantity, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<bool>.Success(true)
                : Result<bool>.Failure($"Failed to update bookmark {request.Input.Id}");
        }

        private async Task<bool> UpdateQuantity(Guid id, int quantity, CancellationToken cancellationToken)
        {
            await _bookmarkRepository
                .UpdateBookmark(id, quantity)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}