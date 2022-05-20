using System.ComponentModel.DataAnnotations;

namespace LaGranjaAPI.DTOs
{
    public class AlimentacionCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Descripcion { get; set; }
        [Required]
        public int Dosis { get; set; }
    }
}
