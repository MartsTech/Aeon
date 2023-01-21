using BuildingBlocks.Core;
using Catalog.Domain.Categories;
using MediatR;

namespace Catalog.Application.Categories.GetCategories
{
    public sealed class GetCategoryByNameQuery
    {
        public class Query : IRequest<Result<CategoryDto>>
        {
            public Query(string name)
            {
                Name = name;
            }

            public string Name { get; }
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
                var result = await GetCategoryByName(request.Name)
                    .ConfigureAwait(false);

                return result == null ? Result<CategoryDto>.Failure("Not found") : Result<CategoryDto>.Success(result);
            }

            private async Task<CategoryDto?> GetCategoryByName(string name)
            {
                Category? category = await _categoryRepository
                    .GetCategoryByName(name)
                    .ConfigureAwait(false);

                return category == null ? null : new CategoryDto(category);
            }
        }
    }
}
