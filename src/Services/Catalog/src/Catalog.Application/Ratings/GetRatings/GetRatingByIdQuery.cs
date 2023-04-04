using BuildingBlocks.Core;
using Catalog.Domain.Ratings;
using MediatR;

namespace Catalog.Application.Ratings.GetRatings;

public sealed class GetRatingByIdQuery
{
    public class Query : IRequest<Result<RatingDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;

        public Handler(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<Result<RatingDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetRatingById(request.Id)
                .ConfigureAwait(false);

            return result != null ? Result<RatingDto>.Success(result) : Result<RatingDto>.Failure("Not found");
        }

        private async Task<RatingDto?> GetRatingById(Guid id)
        {
            Rating? rating = await _ratingRepository
                .GetRatingById(id)
                .ConfigureAwait(false);

            return rating != null ? new RatingDto(rating) : null;
        }
    }
}