using BuildingBlocks.Core;
using Catalog.Domain.Ratings;
using MediatR;

namespace Catalog.Application.Ratings.GetRatings;

public sealed class GetRatingsOfProductQuery
{
    public class Query : IRequest<Result<IList<RatingDto>>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<IList<RatingDto>>>
    {
        private readonly IRatingRepository _ratingRepository;

        public Handler(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<Result<IList<RatingDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetRatingsOfProduct(request.Id)
                .ConfigureAwait(false);

            return result.Count > 0
                ? Result<IList<RatingDto>>.Success(result)
                : Result<IList<RatingDto>>.Failure("No ratings for this product ID");
        }

        private async Task<IList<RatingDto>> GetRatingsOfProduct(Guid productId)
        {
            IList<Rating> comments = await _ratingRepository
                .GetRatingsOfProduct(productId)
                .ConfigureAwait(false);

            return new List<RatingDto>(comments.Select(u => new RatingDto(u)));
        }
    }
}