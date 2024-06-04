using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DTO
{
    public class ClienteOutputDto
    {
        
        public long ClienteId { get; set; }

        public string Rut { get; set; } = string.Empty;

        
        public string Nombre { get; set; } = string.Empty;

       
        public string Apellido { get; set; } = string.Empty;

         public string Direccion { get; set; } = string.Empty;

        
        public string Email { get; set; } = string.Empty;

        
        public string Telefono { get; set; } = string.Empty;
    }
}