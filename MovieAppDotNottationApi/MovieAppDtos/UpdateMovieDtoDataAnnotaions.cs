using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppDomain.Enums;

namespace MovieAppDtos
{
    public class UpdateMovieDtoDataAnnotaions
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(250, ErrorMessage = "Description must be less than 251 characters")]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public GenreEnum Genre { get; set; }
    }
}
