using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Ratings.UpdateRating
{
    public class UpdateRatingInput
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
