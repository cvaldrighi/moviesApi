using PropertyCinema = moviesAPI.Models.Cinema;
using PropertyMovie = moviesAPI.Models.Movie;

namespace moviesAPI.Data.Dtos.Session
{
    public class ReadSessionDto
    {
        public int Id { get; set; }
        public PropertyCinema Cinema { get; set; }
        public PropertyMovie Movie { get; set; }
        public DateTime ClosingTime { get; set; }
        public DateTime StartingTime { get; set; }
    }
}
