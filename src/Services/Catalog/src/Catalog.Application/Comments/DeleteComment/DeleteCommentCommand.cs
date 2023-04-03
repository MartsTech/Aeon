using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain.Comments;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Catalog.Application.Comments.DeleteComment
{
    public sealed class DeleteCommentCommand
    {
        public class Command : IRequest<Result<string>>
        {
            public Command(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<string>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
            {
                _commentRepository = commentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                CommandValidator validator = new CommandValidator();
                ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
                }

                bool success = await DeleteComment(request.Id, cancellationToken)
                    .ConfigureAwait(false);

                return success
                    ? Result<string>.Success($"Deleted comment {request.Id}")
                    : Result<string>.Failure($"Failed to delete comment {request.Id}");
            }

            private async Task<bool> DeleteComment(Guid id, CancellationToken cancellationToken)
            {
                await _commentRepository
                    .DeleteComment(id)
                    .ConfigureAwait(false);

                var changes = await _unitOfWork
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return changes > 0;
            }
        }
    }
}
