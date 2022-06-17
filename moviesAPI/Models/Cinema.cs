using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace moviesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }
        public virtual Address Address { get; set; }

        [JsonIgnore]
        public int AddressId { get; set; }

        public virtual Manager Manager { get; set; }
        [JsonIgnore]
        public int ManagerId { get; set; }
        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }
    }
}
