using BuildingBlocks.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarks.Domain.Wishlists;

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

            public Handler(IWishlistRepository wishlistRepository)
            {
                _wishlistRepository = wishlistRepository;
            }

            public async Task<Result<IList<WishlistDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetAllLists(request.IncludeBookmarks)
                    .ConfigureAwait(false);

                return Result<IList<WishlistDto>>.Success(result);
            }

            private async Task<IList<WishlistDto>> GetAllLists(bool includeBookmarks)
            {
                List<Wishlist> wishlists = await _wishlistRepository
                    .GetAllLists(includeBookmarks)
                    .ConfigureAwait(false);

                return new List<WishlistDto>(wishlists.Select(wishlist => new WishlistDto(wishlist)));
            }
        }
    }
}
