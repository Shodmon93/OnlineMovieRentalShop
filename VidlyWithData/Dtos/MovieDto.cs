using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyWithData.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }

    }
}