using Bookmarks.Domain.Bookmarks;
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

        public Handler(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        public async Task<Result<BookmarkDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetBookmarkById(request.Id)
                .ConfigureAwait(false);

            return result != null ? Result<BookmarkDto>.Success(result) : Result<BookmarkDto>.Failure("Not found");
        }

        private async Task<BookmarkDto?> GetBookmarkById(Guid id)
        {
            Bookmark? bookmark = await _bookmarkRepository
                .GetBookmarkById(id)
                .ConfigureAwait(false);

            return bookmark != null ? new BookmarkDto(bookmark) : null;
        }
    }
}