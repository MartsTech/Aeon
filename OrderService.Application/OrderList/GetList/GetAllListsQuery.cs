using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using MediatR;

namespace Bookmarks.Application.Wishlists.GetList
{
    public sealed class GetAllListsQuery
    {
        public class Query : IRequest<Result<IList<WishlistDto>>>
        {
            public Query(bool includeBookmarks)
            {
                IncludeBookmarks = includeBookmarks;
            }

            public bool IncludeBookmarks { get; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<WishlistDto>>>
        {
            private readonly IWishlistRepository _wishlistRepository;
            private readonly IUserService _userService;

            public Handler(IWishlistRepository wishlistRepository, IUserService userService)
            {
                _wishlistRepository = wishlistRepository;
                _userService = userService;
            }

            public async Task<Result<IList<WishlistDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = _userService.GetCurrentUserId();

                if (userId == null)
                {
                    return Result<IList<WishlistDto>>.Failure("No user id found");
                }
                
                var result = await GetAllLists(request.IncludeBookmarks, new Guid(userId))
                    .ConfigureAwait(false);

                return Result<IList<WishlistDto>>.Success(result);
            }

            private async Task<IList<WishlistDto>> GetAllLists(bool includeBookmarks, Guid userId)
            {
                List<Wishlist> wishlists = await _wishlistRepository
                    .GetAllLists(userId, includeBookmarks)
                    .ConfigureAwait(false);

                return new List<WishlistDto>(wishlists.Select(wishlist => new WishlistDto(wishlist)));
            }
        }
    }
}