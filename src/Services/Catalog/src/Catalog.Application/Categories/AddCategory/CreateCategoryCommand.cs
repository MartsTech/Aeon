using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using Catalog.Domain;
using Catalog.Domain.Categories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Catalog.Application.Categories.AddCategory;

public sealed class CreateCategoryCommand
{
    public class Command : IRequest<Result<CategoryDto>>
    {
        public Command(CreateCategoryInput input)
        {
            Input = input;
        }

        public CreateCategoryInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new CreateCategoryInputValidator());
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

            Category category = _entityFactory.NewCategory(request.Input.Name);

            bool success = await CreateCategory(category, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<CategoryDto>.Success(new CategoryDto(category))
                : Result<CategoryDto>.Failure("Failed to create a category");
        }

        private async Task<bool> CreateCategory(Category category, CancellationToken cancellationToken)
        {
            await _categoryRepository
                .AddCategory(category)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }

}