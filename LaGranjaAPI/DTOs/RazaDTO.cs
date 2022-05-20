using System.ComponentModel.DataAnnotations;

namespace LaGranjaAPI.DTOs
{
    public class RazaDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; }
    }
}
