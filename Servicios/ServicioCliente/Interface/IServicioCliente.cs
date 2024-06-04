using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.DTO;

namespace Test.Servicios.ServicioCliente.Interface
{
    public interface IServicioCliente
    {
        public Task<PaginacionDto<ClienteOutputDto>> GetClientes(PaginacionInputDto pg);

        public Task<bool> SetClente(ClienteInputDto clie);

        public Task<bool> UpDateClente(ClienteUpdDateDto clie);
    }
}