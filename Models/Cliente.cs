using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClienteId { get; set; }

        [Required]
        [StringLength(13)]
        public string Rut { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        
        public string Telefono { get; set; } = string.Empty;
    }
}