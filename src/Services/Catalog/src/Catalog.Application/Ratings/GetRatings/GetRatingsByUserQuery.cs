using BuildingBlocks.Core;
using Catalog.Domain.Ratings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Ratings.GetRatings
{
    public sealed class GetRatingsByUserQuery
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
                var result = await GetRatingsByUser(request.Id)
                    .ConfigureAwait(false);

                return result.Count > 0
                    ? Result<IList<RatingDto>>.Success(result)
                    : Result<IList<RatingDto>>.Failure("No ratings for this user ID");
            }

            private async Task<IList<RatingDto>> GetRatingsByUser(Guid userId)
            {
                IList<Rating> ratings = await _ratingRepository
                    .GetRatingsByUser(userId)
                    .ConfigureAwait(false);

                return new List<RatingDto>(ratings.Select(u => new RatingDto(u)));
            }
        }
    }
}
