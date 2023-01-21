using BuildingBlocks.Core;
using Catalog.Domain.Categories;
using MediatR;

namespace Catalog.Application.Categories.GetCategories
{
    public sealed class GetAllCategoriesQuery
    {
        public class Query : IRequest<Result<IList<CategoryDto>>>
        {
            public Query(bool includeProducts)
            {
                IncludeProducts = includeProducts;
            }
            public bool IncludeProducts { get; }
        }

        public class Handler : IRequestHandler<Query, Result<IList<CategoryDto>>>
        {
            private readonly ICategoryRepository _categoryRepository;

            public Handler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<Result<IList<CategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetAllCategories(request.IncludeProducts)
                    .ConfigureAwait(false);

                return Result<IList<CategoryDto>>.Success(result);
            }

            private async Task<IList<CategoryDto>> GetAllCategories(bool includeProducts)
            {
                List<Category> categories = await _categoryRepository
                    .GetAllCategories(includeProducts)
                    .ConfigureAwait(false);

                return new List<CategoryDto>(categories.Select(category => new CategoryDto(category)));
            }
        }
    }
}