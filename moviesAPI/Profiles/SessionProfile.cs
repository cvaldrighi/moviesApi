using AutoMapper;
using moviesAPI.Data.Dtos.Session;
using moviesAPI.Models;

namespace moviesAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(dto => dto.StartingTime, opts => opts
                .MapFrom(dto => dto.ClosingTime.AddMinutes(dto.Movie.Duration * (-1))));
        }
    }
}
