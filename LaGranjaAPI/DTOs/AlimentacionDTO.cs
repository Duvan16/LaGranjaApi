using System.ComponentModel.DataAnnotations;

namespace LaGranjaAPI.DTOs
{
    public class AlimentacionDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Descripcion { get; set; }
        [Required]
        public int Dosis { get; set; }
    }
}
