using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Ratings.AddRating;

public class AddRatingInput
{
    [Required] public Guid ProductId { get; set; }
    [Required] public int Value { get; set; }
}