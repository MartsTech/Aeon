using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Domain.Comments;
using FluentValidation.Results;

namespace Catalog.Application.Comments.AddComment
{
    public sealed class AddCommentCommand
    {
        public class Command : IRequest<Result<CommentDto>>
        {
            public Command(AddCommentInput input)
            {
                Input = input;
            }

            public AddCommentInput Input { get; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Input).SetValidator(new AddCommentInputValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<CommentDto>>
        {
            private readonly IEntityFactory _entityFactory;
            private readonly ICommentRepository _commentRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IEntityFactory entityFactory, ICommentRepository commentRepository, IUnitOfWork unitOfWork)
            {
                _entityFactory = entityFactory;
                _commentRepository = commentRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<CommentDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                CommandValidator validator = new CommandValidator();
                ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    return Result<CommentDto>.Failure($"{string.Join('\n', validation.Errors)}");
                }

                Comment comment = _entityFactory.NewComment(Guid.NewGuid(), request.Input.ProductId, request.Input.Content);
                //placeholder GUIDs!
                //TODO: add authentication

                bool success = await AddComment(comment, cancellationToken)
                    .ConfigureAwait(false);

                return success
                    ? Result<CommentDto>.Success(new CommentDto(comment))
                    : Result<CommentDto>.Failure("Failed to create a comment");
            }

            private async Task<bool> AddComment(Comment comment, CancellationToken cancellationToken)
            {
                await _commentRepository
                    .AddComment(comment)
                    .ConfigureAwait(false);

                var changes = await _unitOfWork
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return changes > 0;
            }
        }
    }
}
