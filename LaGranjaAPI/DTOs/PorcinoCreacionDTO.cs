using LaGranjaAPI.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LaGranjaAPI.DTOs
{
    public class PorcinoCreacionDTO
    {
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
