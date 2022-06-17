using System.ComponentModel.DataAnnotations;

namespace moviesAPI.Data.Dtos.Address
{
    public class UpdateAddressDto
    {
        [Required(ErrorMessage = "O campo rua é obrigatório")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        public string District { get; set; }

        [Required(ErrorMessage = "O campo número é obrigatório")]
        public int Number { get; set; }
    }
}
