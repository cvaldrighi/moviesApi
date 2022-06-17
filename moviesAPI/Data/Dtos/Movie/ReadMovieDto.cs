using System.ComponentModel.DataAnnotations;

namespace moviesAPI.Data.Dtos.Movie
{
    public class ReadMovieDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Director { get; set; }
        public string Gender { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duration { get; set; }
        public DateTime ConsultTime { get; set; }
    }
}
