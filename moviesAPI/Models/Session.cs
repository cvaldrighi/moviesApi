using System.ComponentModel.DataAnnotations;

namespace moviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
