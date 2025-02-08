using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieApp.Models
{
    public class Movie
    {
        //primary key

        public int MovieId { get; set; }

        [Required(ErrorMessage ="Please enter a name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1900, 2025, ErrorMessage = "Year must be between 1900 and 2025")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating")]
        [Range(1, 5, ErrorMessage = "Year must be between 1 and 5")]
        public int? Rating { get; set; }
        //readonly property for slug
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();

        //foreign key
        //your entities are easier to work with when you include fk that refer to the pk in the related class entity
        [Required(ErrorMessage = "Please enter a genre")]
        public string GenreId { get; set; } = string.Empty;

        //navigation property that links the two table together
        [ValidateNever]
        public Genre Genre { get; set; } = null!;
    }
}
