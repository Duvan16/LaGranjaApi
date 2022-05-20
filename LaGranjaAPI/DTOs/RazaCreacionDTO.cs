using System.ComponentModel.DataAnnotations;

namespace LaGranjaAPI.DTOs
{
    public class RazaCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; }
    }
}
