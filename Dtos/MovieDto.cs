using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto GenreDto { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? AddedDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }


    }
}