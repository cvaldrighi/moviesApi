namespace moviesAPI.Data.Dtos.Session
{
    public class CreateSessionDto
    {
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
