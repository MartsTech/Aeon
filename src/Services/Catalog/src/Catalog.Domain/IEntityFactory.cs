﻿using Catalog.Domain.Categories;
using Catalog.Domain.Comments;
using Catalog.Domain.Products;
using Catalog.Domain.Ratings;

namespace Catalog.Domain;

public interface IEntityFactory
{
    Product NewProduct(string title, string? description, decimal price, decimal? discount, Guid categoryId,
        string? image, int quantity);
    Product NewProductWithExistingId(Guid id, string title, string? description, decimal price, decimal? discount,
        Guid categoryId,
        string? image, int quantity);

    Category NewCategory(string name);

    Comment NewComment(Guid userId, Guid productId, string content);

    Upvote NewVote(Guid userId, Guid commentId);

    Rating NewRating(Guid userId, Guid productId, int value); }