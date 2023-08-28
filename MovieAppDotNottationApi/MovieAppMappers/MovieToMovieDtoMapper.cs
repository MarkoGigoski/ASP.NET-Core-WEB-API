using MovieAppDomain.Models;
using MovieAppDtos;

namespace MovieAppMappers
{
    public static class MovieToMovieDtoMapper
    {
        public static MovieDto ConversionToDto(this Movie movie)
        {
            return new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Year = movie.Year,
            };
        }
    }
}
