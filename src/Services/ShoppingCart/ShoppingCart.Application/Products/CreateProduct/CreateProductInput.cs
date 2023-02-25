﻿using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Products.CreateProduct
{
    public class CreateProductInput
    {
        [Required]
        [MaxLength(90)]
        public string Title { get; set; } 
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string? Image { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
