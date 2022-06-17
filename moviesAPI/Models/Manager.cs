using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace moviesAPI.Models
{
    public class Manager
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
