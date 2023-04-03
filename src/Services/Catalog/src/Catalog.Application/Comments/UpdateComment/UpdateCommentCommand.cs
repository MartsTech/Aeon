using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using MediatR;
using BuildingBlocks.Authentication;
using Catalog.Domain.Comments;
using FluentValidation.Results;

namespace Catalog.Application.Comments.UpdateComment;

public sealed class UpdateCommentCommand
{
    public class Command : IRequest<Result<CommentDto>>
    {
        public Command(UpdateCommentInput input)
        {
            Input = input;
        }

        public UpdateCommentInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateCommentInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<CommentDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            string? userId = _userService.GetCurrentUserId();
            if (userId == null)
            {
                return Result<CommentDto>.Failure("Not authenticated!");
            }

            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<CommentDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            Comment? comment = await _commentRepository.GetCommentById(request.Input.Id);
            if (comment == null)
            {
                return Result<CommentDto>.Failure($"Comment with ID {request.Input.Id} not found");
            }

            if (comment.UserId != new Guid(userId))
            {
                return Result<CommentDto>.Failure("Access denied");
            }

            bool success = await UpdateComment(request.Input.Id, request.Input.Content, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<CommentDto>.Success(new CommentDto(comment))
                : Result<CommentDto>.Failure($"Failed to update comment {request.Input.Id}");
        }

        private async Task<bool> UpdateComment(Guid id, string newComment, CancellationToken cancellationToken)
        {
            await _commentRepository
                .UpdateComment(id, newComment)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}