using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.DTO;
using Test.Models;
using Test.Servicios.ServicioCliente.Interface;

namespace Test.Servicios.ServicioCliente
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly ContextoBD _cn;
        public ServicioCliente(ContextoBD cn)
        {
            _cn = cn;
        }
        public async Task<PaginacionDto<ClienteOutputDto>> GetClientes(PaginacionInputDto pg)
        {

            var res = await _cn.Cliente
            .Skip((pg.Pagina - 1) * pg.CantidadRegistros)
            .Take(pg.CantidadRegistros)
            .Select(x => new ClienteOutputDto
            {
                ClienteId = x.ClienteId,
                Rut = x.Rut,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Direccion = x.Direccion,
                Email = x.Email,
                Telefono = x.Telefono
            }).ToListAsync();

            return new PaginacionDto<ClienteOutputDto>()
            {
                CantidadRegistros = pg.CantidadRegistros,
                Pagina = pg.Pagina,
                TotalRegistros = res.Count(),
                Datos = res
            };
        }

        public async Task<List<ClienteOutputDto>> GetClientes()
        {
            var res = await _cn.Cliente.Select(x=> new ClienteOutputDto{
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Rut = x.Rut,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email
            }).ToListAsync();
            return res;
        }

        public async Task<bool> SetClente(ClienteInputDto clie)
        {

            var reg = new Cliente{
                Nombre = clie.Nombre,
                Apellido = clie.Apellido,
                Rut = clie.Rut,
                Direccion = clie.Direccion,
                Telefono = clie.Telefono,
                Email = clie.Email
            };
            await _cn.Cliente.AddAsync(reg);
            await _cn.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpDateClente(ClienteUpdDateDto clie)
        {
            var cliente = await _cn.Cliente.FindAsync(clie.Id);
            if(cliente == null)
                return false;
            
            cliente.Nombre = clie.Nombre;
            cliente.Apellido = clie.Apellido;
            cliente.Rut = clie.Rut;
            cliente.Direccion = clie.Direccion;
            cliente.Telefono = clie.Telefono;
            cliente.Email = clie.Email;
            
            _cn.Cliente.Update(cliente);
            await _cn.SaveChangesAsync();
            return true;
        }
    }
}