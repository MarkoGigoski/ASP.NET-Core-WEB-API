using MovieAppDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppDomain.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(250, ErrorMessage ="Title cant be longer then 250 characters.")]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public GenreEnum Genre { get; set; }
    }
}
