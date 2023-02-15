using Bookmarks.Application.Bookmarks;
using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Core;
using MediatR;

namespace Bookmarks.Application.Wishlists.GetList;

public sealed class GetListByIdQuery
{
    public class Query : IRequest<Result<WishlistDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<WishlistDto>>
    {
        private readonly IWishlistRepository _wishlistRepository;

        public Handler(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task<Result<WishlistDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetListById(request.Id)
                .ConfigureAwait(false);

            return result != null ? Result<WishlistDto>.Success(result) : Result<WishlistDto>.Failure("Not found");
        }

        private async Task<WishlistDto?> GetListById(Guid id)
        {
            Wishlist? wishlist = await _wishlistRepository
                .GetListById(id)
                .ConfigureAwait(false);

            return wishlist != null ? new WishlistDto(wishlist) : null;
        }
    }
}