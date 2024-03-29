﻿using Catalog.Domain.Categories;
using Catalog.Domain.Comments;
using Catalog.Domain.Ratings;

namespace Catalog.Domain.Products
{
    public class Product : IProduct
    {
        public Product(Guid id, string title, string? description, decimal price, decimal? discount, Guid categoryId, string? image, int quantity)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Discount = discount;
            CategoryId = categoryId;
            Image = image;
            Quantity = quantity;
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        public Guid Id { get; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public ICollection<Rating> Ratings { get; }
        public ICollection<Comment> Comments { get; }
    }
}
