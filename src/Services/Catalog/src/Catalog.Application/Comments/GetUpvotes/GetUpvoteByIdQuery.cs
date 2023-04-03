using BuildingBlocks.Core;
using Catalog.Domain.Comments;
using MediatR;

namespace Catalog.Application.Comments.GetUpvotes
{
    public sealed class GetUpvoteByIdQuery
    {
        public class Query : IRequest<Result<UpvoteDto>>
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; }
        }

        public class Handler : IRequestHandler<Query, Result<UpvoteDto>>
        {
            private readonly IUpvoteRepository _upvoteRepository;

            public Handler(IUpvoteRepository upvoteRepository)
            {
                _upvoteRepository = upvoteRepository;
            }

            public async Task<Result<UpvoteDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetUpvoteById(request.Id)
                    .ConfigureAwait(false);

                return result != null ? Result<UpvoteDto>.Success(result) : Result<UpvoteDto>.Failure("Not found");
            }

            private async Task<UpvoteDto?> GetUpvoteById(Guid id)
            {
                Upvote? upvote = await _upvoteRepository
                    .GetUpvoteById(id)
                    .ConfigureAwait(false);

                return upvote != null ? new UpvoteDto(upvote) : null;
            }
        }
    }
}
