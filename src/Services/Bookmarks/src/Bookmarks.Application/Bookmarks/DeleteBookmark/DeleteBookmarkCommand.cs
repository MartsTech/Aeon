using Bookmarks.Domain.Bookmarks;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Bookmarks.Application.Bookmarks.DeleteBookmark;

public sealed class DeleteBookmarkCommand
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
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IBookmarkRepository bookmarkRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _bookmarkRepository = bookmarkRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<string>.Failure("No user id found");
            }
            
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validation.IsValid)
            {
                return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await DeleteBookmark(request.Id, new Guid(userId), cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted bookmark {request.Id}")
                : Result<string>.Failure($"Failed to delete bookmark {request.Id}");
        }

        private async Task<bool> DeleteBookmark(Guid id, Guid userId, CancellationToken cancellationToken)
        {
            await _bookmarkRepository
                .DeleteBookmark(id, userId)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}