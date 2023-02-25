using BuildingBlocks.Core;
using Catalog.Domain.Categories;
using MediatR;

namespace Catalog.Application.Categories.GetCategories
{
    public sealed class GetCategoryByIdQuery
    {
        public class Query : IRequest<Result<CategoryDto>>
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; }
        }

        public class Handler : IRequestHandler<Query, Result<CategoryDto>>
        {
            private readonly ICategoryRepository _categoryRepository;

            public Handler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<Result<CategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetCategoryById(request.Id)
                    .ConfigureAwait(false);

                return result == null ? Result<CategoryDto>.Failure("Not found") : Result<CategoryDto>.Success(result);
            }

            private async Task<CategoryDto?> GetCategoryById(Guid id)
            {
                Category? category = await _categoryRepository
                    .GetCategoryById(id)
                    .ConfigureAwait(false);

                return category == null ? null : new CategoryDto(category);
            }
        }
    }
}