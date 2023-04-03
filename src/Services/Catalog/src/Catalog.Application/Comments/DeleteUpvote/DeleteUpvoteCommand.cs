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
using FluentValidation.Results;

namespace Catalog.Application.Comments.DeleteUpvote
{
    public sealed class DeleteUpvoteCommand
    {public class Command : IRequest<Result<string>>
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
            private readonly IUpvoteRepository _upvoteRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IUserService _userService;

            public Handler(IUpvoteRepository upvoteRepository, IUnitOfWork unitOfWork, IUserService userService)
            {
                _upvoteRepository = upvoteRepository;
                _unitOfWork = unitOfWork;
                _userService = userService;
            }

            public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                string? userId = _userService.GetCurrentUserId();
                if (userId == null)
                {
                    return Result<string>.Failure("Not authenticated!");
                }

                CommandValidator validator = new CommandValidator();
                ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
                }

                Upvote? upvote = await _upvoteRepository.GetUpvoteById(request.Id).ConfigureAwait(false);
                if (upvote != null && upvote.UserId != new Guid(userId))
                {
                    return Result<string>.Failure("Access denied");
                }

                bool success = await DeleteUpvote(request.Id, cancellationToken)
                    .ConfigureAwait(false);

                return success
                    ? Result<string>.Success($"Deleted upvote {request.Id}")
                    : Result<string>.Failure($"Failed to delete upvote {request.Id}");
            }

            private async Task<bool> DeleteUpvote(Guid id, CancellationToken cancellationToken)
            {
                await _upvoteRepository
                    .DeleteUpvote(id)
                    .ConfigureAwait(false);

                var changes = await _unitOfWork
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return changes > 0;
            }
        }
    }
}
