using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Entities
{
    public class Porcino
    {
        public int Id { get; set; }
        [Required]
        public int RazaId { get; set; }
        public Raza Raza { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public int AlimentacionId { get; set; }
        public Alimentacion Alimentacion { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public decimal Peso { get; set; }
    }
}
