using AutoMapper;
using FluentResults;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Manager;
using moviesAPI.Models;

namespace moviesAPI.Services
{
    public class ManagerService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public ManagerService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadManagerDto AddManager(CreateManagerDto dto)
        {
            Manager manager = _mapper.Map<Manager>(dto);
            _context.Managers.Add(manager);
            _context.SaveChanges();

            return _mapper.Map<ReadManagerDto>(manager);
        }

        public ReadManagerDto GetManagersById(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                ReadManagerDto managerDto = _mapper.Map<ReadManagerDto>(manager);

                return managerDto;
            }

            return null;
        }

        public Result DeleteManager(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager == null)
            {
                return Result.Fail("Gerente não encontrado.");
            }
            _context.Remove(manager);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
