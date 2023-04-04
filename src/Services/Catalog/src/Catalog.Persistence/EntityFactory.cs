using Catalog.Domain;
using Catalog.Domain.Categories;
using Catalog.Domain.Comments;
using Catalog.Domain.Products;
using Catalog.Domain.Ratings;

namespace Catalog.Persistence;

public class EntityFactory : IEntityFactory
{
    public Product NewProduct(string title, string? description, decimal price, decimal? discount,
        Guid categoryId,
        string? image, int quantity)
    {
        return new Product(Guid.NewGuid(), title, description, price, discount, categoryId, image, quantity);
    }

    public Product NewProductWithExistingId(Guid id, string title, string? description, decimal price,
        decimal? discount,
        Guid categoryId,
        string? image, int quantity)
    {
        return new Product(id, title, description, price, discount, categoryId, image, quantity);
    }

    public Category NewCategory(string name)
    {
        return new Category(Guid.NewGuid(), name);
    }

    public Category NewCategoryWithExistingId(Guid id, string name)
    {
        return new Category(id, name);
    }

    public Comment NewComment(Guid userId, Guid productId, string content)
    {
        return new Comment(Guid.NewGuid(), userId, productId, content);
    }

    public Comment NewCommentWithExistingId(Guid id, Guid userId, Guid productId, string content)
    {
        return new Comment(id, userId, productId, content);
    }

    public Upvote NewVote(Guid userId, Guid commentId)
    {
        return new Upvote(Guid.NewGuid(), userId, commentId);
    }

    public Upvote NewVoteWithExistingId(Guid id, Guid userId, Guid commentId)
    {
        return new Upvote(id, userId, commentId);
    }

    public Rating NewRating(Guid userId, Guid productId, int value)
    {
        return new Rating(Guid.NewGuid(), userId, productId, value);
    }

    public Rating NewRatingWithExistingId(Guid id, Guid userId, Guid productId, int value)
    {
        return new Rating(id, userId, productId, value);
    }
}