using Bookmarks.Domain.Bookmarks;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace Bookmarks.Application.Bookmarks.GetBookmark;

public sealed class GetBookmarkByIdQuery
{
    public class Query : IRequest<Result<BookmarkDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<BookmarkDto>>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUserService _userService;

        public Handler(IBookmarkRepository bookmarkRepository, IUserService userService)
        {
            _bookmarkRepository = bookmarkRepository;
            _userService = userService;
        }

        public async Task<Result<BookmarkDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<BookmarkDto>.Failure("No user id found");
            }
            
            var result = await GetBookmarkById(request.Id, new Guid(userId))
                .ConfigureAwait(false);

            return result != null ? Result<BookmarkDto>.Success(result) : Result<BookmarkDto>.Failure("Not found");
        }

        private async Task<BookmarkDto?> GetBookmarkById(Guid id, Guid userId)
        {
            Bookmark? bookmark = await _bookmarkRepository
                .GetBookmarkById(id, userId)
                .ConfigureAwait(false);

            return bookmark != null ? new BookmarkDto(bookmark) : null;
        }
    }
}