using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Entities
{
    public class Raza
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; }
    }
}
