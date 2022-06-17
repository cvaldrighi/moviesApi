using AutoMapper;
using FluentResults;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Address;
using moviesAPI.Models;

namespace moviesAPI.Services
{
    public class AddressService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AddressService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAddressDto AddAddress(CreateAddressDto addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return _mapper.Map<ReadAddressDto>(address); 
        }

        public List<ReadAddressDto> GetAddress()
        {
            List<Address> addresses = _context.Addresses.ToList();
            if(addresses == null)
            {
                return null;
            }
            
            return _mapper.Map<List<ReadAddressDto>>(addresses); 
        }

        public ReadAddressDto GetAddressesById(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
                return addressDto;
            }

            return null;
        }

        public Result UpdateAddress(int id, UpdateAddressDto addressDto)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _mapper.Map(addressDto, address);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteAddress(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _context.Remove(address);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
