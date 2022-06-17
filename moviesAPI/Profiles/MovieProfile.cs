using AutoMapper;
using moviesAPI.Data.Dtos.Movie;
using moviesAPI.Models;

namespace moviesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<Movie, ReadMovieDto>();
        }
    }
}
