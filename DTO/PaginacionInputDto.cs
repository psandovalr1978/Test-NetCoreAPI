using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DTO
{
    public class PaginacionInputDto
    {
        public int Pagina { get; set; } = 1;

        public int CantidadRegistros { get; set; } = 10;

    }
}