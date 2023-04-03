using BuildingBlocks.Core;
using Catalog.Domain.Comments;
using MediatR;

namespace Catalog.Application.Comments.GetComments;

public sealed class GetCommentByIdQuery
{
    public class Query : IRequest<Result<CommentDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;

        public Handler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result<CommentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetCommentById(request.Id)
                .ConfigureAwait(false);

            return result != null ? Result<CommentDto>.Success(result) : Result<CommentDto>.Failure("Not found");
        }

        private async Task<CommentDto?> GetCommentById(Guid id)
        {
            Comment? comment = await _commentRepository
                .GetCommentById(id)
                .ConfigureAwait(false);

            return comment != null ? new CommentDto(comment) : null;
        }
    }
}