using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Authentication;
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
        private readonly IUserService _userService;

        public Handler(IWishlistRepository wishlistRepository, IUserService userService)
        {
            _wishlistRepository = wishlistRepository;
            _userService = userService;
        }

        public async Task<Result<WishlistDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<WishlistDto>.Failure("No user id found");
            }
            
            var result = await GetListById(request.Id, new Guid(userId))
                .ConfigureAwait(false);

            return result != null ? Result<WishlistDto>.Success(result) : Result<WishlistDto>.Failure("Not found");
        }

        private async Task<WishlistDto?> GetListById(Guid id, Guid userId)
        {
            Wishlist? wishlist = await _wishlistRepository
                .GetListById(userId, id)
                .ConfigureAwait(false);

            return wishlist != null ? new WishlistDto(wishlist) : null;
        }
    }
}