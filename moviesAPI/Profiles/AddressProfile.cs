using AutoMapper;
using moviesAPI.Data.Dtos.Address;
using moviesAPI.Models;

namespace moviesAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
        }

    }
}
