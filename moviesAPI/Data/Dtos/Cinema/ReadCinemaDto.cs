using System.ComponentModel.DataAnnotations;
using PropertyAddress = moviesAPI.Models.Address;

namespace moviesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
         

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Name { get; set; }

        public PropertyAddress Address { get; set; }

    }
}
