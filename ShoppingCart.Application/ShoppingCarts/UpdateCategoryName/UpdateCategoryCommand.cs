using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain;
using Catalog.Domain.Categories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Catalog.Application.Categories.UpdateCategoryName;

public sealed class UpdateCategoryCommand
{
    public class Command : IRequest<Result<CategoryDto>>
    {
        public Command(UpdateCategoryInput input)
        {
            Input = input;
        }

        public UpdateCategoryInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateCategoryInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<CategoryDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IEntityFactory entityFactory, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CategoryDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<CategoryDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            Category? category = await _categoryRepository.GetCategoryById(request.Input.Id);
            if (category == null)
            {
                return Result<CategoryDto>.Failure($"Category with ID {request.Input.Id} not found");
            }

            bool success = await UpdateCategory(request.Input.Id, request.Input.NewName, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<CategoryDto>.Success(new CategoryDto(category))
                : Result<CategoryDto>.Failure($"Failed to update category {request.Input.Id}");
        }

        private async Task<bool> UpdateCategory(Guid id, string newName, CancellationToken cancellationToken)
        {
            await _categoryRepository
                .UpdateCategoryName(id, newName)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}