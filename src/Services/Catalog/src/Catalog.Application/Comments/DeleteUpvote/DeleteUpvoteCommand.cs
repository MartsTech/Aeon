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

            public Handler(IUpvoteRepository upvoteRepository, IUnitOfWork unitOfWork)
            {
                _upvoteRepository = upvoteRepository;
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
