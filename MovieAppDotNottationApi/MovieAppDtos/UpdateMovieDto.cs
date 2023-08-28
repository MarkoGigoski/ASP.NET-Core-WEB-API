using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppDomain.Enums;
using MovieAppDomain.Models;

namespace MovieAppDtos
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public GenreEnum Genre { get; set; }

        public Movie ToMovieForUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
