using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain.Categories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Catalog.Application.Categories.DeleteCategory;

public sealed class DeleteCategoryCommand
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
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

            bool success = await DeleteCategory(request.Id, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted empty category {request.Id}")
                : Result<string>.Failure($"Failed to delete category {request.Id}: not found or not empty!");
        }

        private async Task<bool> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            await _categoryRepository
                .DeleteCategory(id)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}