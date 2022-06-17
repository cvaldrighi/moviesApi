using AutoMapper;
using moviesAPI.Data.Dtos.Cinema;
using moviesAPI.Models;

namespace moviesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
       public CinemaProfile()
       {
                CreateMap<CreateCinemaDto, Cinema>();
                CreateMap<UpdateCinemaDto, Cinema>();
                CreateMap<Cinema, ReadCinemaDto>();
       }

    }
}
