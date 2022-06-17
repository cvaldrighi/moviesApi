using AutoMapper;
using moviesAPI.Data.Dtos.Manager;
using moviesAPI.Models;

namespace moviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>()
                .ForMember(manager => manager.Cinemas, opts => opts
                .MapFrom(manager => manager.Cinemas.Select
                (c => new { c.Id, c.Name, c.Address, c.AddressId })));
        }

    }
}
