using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DTO
{
    public class PaginacionDto<T>
    {
        public int Pagina { get; set; } = 0;

        public int CantidadRegistros { get; set; } = 0;

        public int TotalRegistros { get; set; } = 0;

        public List<T> Datos { get; set; } = new List<T>();
    }
}