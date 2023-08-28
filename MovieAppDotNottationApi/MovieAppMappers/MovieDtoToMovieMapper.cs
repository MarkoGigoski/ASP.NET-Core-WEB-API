using MovieAppDomain.Models;
using MovieAppDtos;

namespace MovieAppMappers
{
    public static class MovieDtoToMovieMapper
    {
        public static Movie ConversionToMovie(this MovieDto movieDto)
        {
            return new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Genre = movieDto.Genre,
                Year = movieDto.Year,
            };
        }
    }
}
