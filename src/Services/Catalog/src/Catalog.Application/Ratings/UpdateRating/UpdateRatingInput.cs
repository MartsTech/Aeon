using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Ratings.UpdateRating;

public class UpdateRatingInput
{
    [Required] public Guid Id { get; set; }
    [Required] public int Value { get; set; }
}