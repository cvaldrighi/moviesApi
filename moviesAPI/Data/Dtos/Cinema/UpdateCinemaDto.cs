using System.ComponentModel.DataAnnotations;

namespace moviesAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo name é obrigatório")]
        public string Name { get; set; }
    }
}
