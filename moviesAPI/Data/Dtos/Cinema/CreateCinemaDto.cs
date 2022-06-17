using System.ComponentModel.DataAnnotations;

namespace moviesAPI.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }

        public int ManagerId { get; set; }
    }
}
