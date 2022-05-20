using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Entities
{
    public class Alimentacion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Descripcion { get; set; }
        [Required]
        public int Dosis { get; set; }
    }
}
