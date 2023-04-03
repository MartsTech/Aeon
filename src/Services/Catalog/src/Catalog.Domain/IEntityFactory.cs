using Catalog.Domain.Categories;
using Catalog.Domain.Comments;
using Catalog.Domain.Products;

namespace Catalog.Domain;

public interface IEntityFactory
{
    Product NewProduct(string title, string? description, decimal price, decimal? discount, Guid categoryId,
        string? image, int quantity);
    Product NewProductWithExistingId(Guid id, string title, string? description, decimal price, decimal? discount,
        Guid categoryId,
        string? image, int quantity);

    Category NewCategory(string name);
    Category NewCategoryWithExistingId(Guid id, string name);

    Comment NewComment(Guid userId, Guid productId, string content);
    Comment NewCommentWithExistingId(Guid id, Guid userId, Guid productId, string content);

    Upvote NewVote(Guid userId, Guid commentId);
    Upvote NewVoteWithExistingId(Guid id, Guid userId, Guid commentId);
}