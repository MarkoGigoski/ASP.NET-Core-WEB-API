using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppDomain.Enums;

namespace MovieAppDtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public GenreEnum Genre { get; set; }

        public void ToMovieForUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
