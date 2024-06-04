using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.DTO;
using Test.Servicios.ServicioCliente.Interface;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IServicioCliente _servicio;

        public ClientesController(IServicioCliente servicio)
        {
            _servicio = servicio;
        }

        [HttpPost("ObtenerClientes")]
        public async Task<ActionResult<PaginacionDto<ClienteOutputDto>>> ObtenerClientes(PaginacionInputDto pg)
        {
            return await _servicio.GetClientes(pg);
        }

        [HttpPost("SetCliente")]
        public async Task<ActionResult<bool>> SetCliente(ClienteInputDto cli)
        {
            return await _servicio.SetClente(cli);
        }

        [HttpPut("UpDateCliente")]
        public async Task<ActionResult<bool>> UpDateCliente(ClienteUpdDateDto cli)
        {
            return await _servicio.UpDateClente(cli);
        }

    }
}