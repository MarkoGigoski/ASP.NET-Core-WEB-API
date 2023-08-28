using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MovieAppDomain.Models;
using MovieAppDtos;

namespace MovieAppMappers
{
    public abstract class UpdateMovieDtoToMovieMapper
    {
        public static UpdateMovieDto ToMovieForUpdate(Movie movie)
        {
            return new UpdateMovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Year = movie.Year,
            };
        }
    }
    
}
