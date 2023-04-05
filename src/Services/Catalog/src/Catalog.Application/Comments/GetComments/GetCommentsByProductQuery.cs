using BuildingBlocks.Core;
using Catalog.Domain.Comments;
using MediatR;

namespace Catalog.Application.Comments.GetComments;

public sealed class GetCommentsByProductQuery
{
    public class Query : IRequest<Result<IList<CommentDto>>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<IList<CommentDto>>>
    {
        private readonly ICommentRepository _commentRepository;

        public Handler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result<IList<CommentDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetCommentsByProduct(request.Id)
                .ConfigureAwait(false);

            return result.Count > 0
                ? Result<IList<CommentDto>>.Success(result)
                : Result<IList<CommentDto>>.Failure("No comments for this product ID");
        }

        private async Task<IList<CommentDto>> GetCommentsByProduct(Guid commentId)
        {
            IList<Comment> comments = await _commentRepository
                .GetCommentsByProduct(commentId)
                .ConfigureAwait(false);

            return new List<CommentDto>(comments.Select(u => new CommentDto(u)));
        }
    }
}