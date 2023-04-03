using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain.Comments;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Authentication;
using Catalog.Domain;
using FluentValidation.Results;

namespace Catalog.Application.Comments.AddUpvote
{
    public sealed class AddUpvoteCommand
    {
        public class Command : IRequest<Result<UpvoteDto>>
        {
            public Command(AddUpvoteInput input)
            {
                Input = input;
            }

            public AddUpvoteInput Input { get; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Input).SetValidator(new AddUpvoteInputValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<UpvoteDto>>
        {
            private readonly IEntityFactory _entityFactory;
            private readonly IUpvoteRepository _upvoteRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IUserService _userService;

            public Handler(IEntityFactory entityFactory, IUpvoteRepository upvoteRepository, IUnitOfWork unitOfWork, IUserService userService)
            {
                _entityFactory = entityFactory;
                _upvoteRepository = upvoteRepository;
                _unitOfWork = unitOfWork;
                _userService = userService;
            }

            public async Task<Result<UpvoteDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                string? userId = _userService.GetCurrentUserId();
                if (userId == null)
                {
                    return Result<UpvoteDto>.Failure("Not authenticated!");
                }

                CommandValidator validator = new CommandValidator();
                ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    return Result<UpvoteDto>.Failure($"{string.Join('\n', validation.Errors)}");
                }

                Upvote upvote = _entityFactory.NewVote(new Guid(userId), request.Input.CommentId);

                bool success = await AddUpvote(upvote, cancellationToken)
                    .ConfigureAwait(false);

                return success
                    ? Result<UpvoteDto>.Success(new UpvoteDto(upvote))
                    : Result<UpvoteDto>.Failure("Failed to upvote or already upvoted");
            }

            private async Task<bool> AddUpvote(Upvote upvote, CancellationToken cancellationToken)
            {
                await _upvoteRepository
                    .AddUpvote(upvote)
                    .ConfigureAwait(false);

                var changes = await _unitOfWork
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return changes > 0;
            }
        }
    }
}
