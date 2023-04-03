using BuildingBlocks.Core;
using Catalog.Domain.Comments;
using MediatR;

namespace Catalog.Application.Comments.GetUpvotes
{
    public sealed class GetUpvotesOfCommentQuery
    {
        public class Query : IRequest<Result<IList<UpvoteDto>>>
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<UpvoteDto>>>
        {
            private readonly IUpvoteRepository _upvoteRepository;

            public Handler(IUpvoteRepository upvoteRepository)
            {
                _upvoteRepository = upvoteRepository;
            }

            public async Task<Result<IList<UpvoteDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetUpvotesOfComment(request.Id)
                    .ConfigureAwait(false);

                return result.Count > 0 ? Result<IList<UpvoteDto>>.Success(result) : Result<IList<UpvoteDto>>.Failure("No upvotes for this comment ID");
            }

            private async Task<IList<UpvoteDto>> GetUpvotesOfComment(Guid commentId)
            {
                IList<Upvote> upvotes = await _upvoteRepository
                    .GetUpvotesOfComment(commentId)
                    .ConfigureAwait(false);

                return new List<UpvoteDto>(upvotes.Select(u => new UpvoteDto(u)));
            }
        }
    }
}
