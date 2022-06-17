using AutoMapper;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Session;
using moviesAPI.Models;

namespace moviesAPI.Services
{
    public class SessionService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public SessionService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessionDto AddSession(CreateSessionDto dto)
        {
            Session session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();

            return _mapper.Map<ReadSessionDto>(session);
        }

        public ReadSessionDto GetSessionsById(int id)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {
                ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);
                return sessionDto;
            }

            return null;
        }
    }
}
