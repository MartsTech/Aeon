using Bookmarks.Domain;
using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Bookmarks.Application.Bookmarks.AddBookmark;

public sealed class AddBookmarkCommand
{
    public class Command : IRequest<Result<BookmarkDto>>
    {
        public Command(AddBookmarkInput input)
        {
            Input = input;
        }

        public AddBookmarkInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new AddBoookmarkInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<BookmarkDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IEntityFactory entityFactory, IBookmarkRepository bookmarkRepository,
            IWishlistRepository wishlistRepository, IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _bookmarkRepository = bookmarkRepository;
            _wishlistRepository = wishlistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<BookmarkDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<BookmarkDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            Wishlist? wishlist = await _wishlistRepository.GetListById(request.Input.ListId).ConfigureAwait(false);
            if (wishlist == null)
            {
                return Result<BookmarkDto>.Failure($"List {request.Input.ListId} not found");
            }

            Bookmark bookmark =
                _entityFactory.NewBookmark(request.Input.ProductId, request.Input.Quantity, request.Input.ListId);

            bool success = await CreateBookmark(bookmark, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<BookmarkDto>.Success(new BookmarkDto(bookmark))
                : Result<BookmarkDto>.Failure("Failed to create a bookmark");
        }

        private async Task<bool> CreateBookmark(Bookmark bookmark, CancellationToken cancellationToken)
        {
            await _bookmarkRepository
                .AddBookmark(bookmark, bookmark.ListId)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}