using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DTO
{
    public class ClienteInputDto
    {
       

        [Required]
        [StringLength(13, ErrorMessage = "El RUT no puede exceder los 13 caracteres.")]
        public string Rut { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(250, ErrorMessage = "La dirección no puede exceder los 250 caracteres.")]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede exceder los 50 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        public string Telefono { get; set; } = string.Empty;
    }
}