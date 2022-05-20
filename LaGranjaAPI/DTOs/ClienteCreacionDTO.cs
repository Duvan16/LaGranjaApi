using System.ComponentModel.DataAnnotations;

namespace LaGranjaAPI.DTOs
{
    public class ClienteCreacionDTO
    {

        [Required]
        [StringLength(maximumLength: 15)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(maximumLength: 10)]
        public string Telefono { get; set; }
    }
}
