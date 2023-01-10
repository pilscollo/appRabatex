﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoRabatexOficial.Dto;
using ProyectoRabatexOficial.Models;

namespace ProyectoRabatexOficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public DbProyectoRabatexContext _context;
        public ClienteController(DbProyectoRabatexContext context)
        {
            _context = context;
        }

        /*
         * Listar todos los clientes x 
         * listar filtrar por localidad x
         * obtener cliente x
         * modificar cliente
         * agregar pedido 
         * eliminar producto
         * agregar cliente x
         * modificar cliente */
        /*
        [HttpPost]
        [Route("/cliente/agregarProducto/{id}")]
        public async Task<IActionResult> agregarProducto(int id,string nombreProducto)
        {
            
            Producto producto = _context.Productos.Where(o => o.Nombre.Equals(nombreProducto)).FirstOrDefault();
            if (producto != null)
            {
                Cliente cliente =  _context.Clientes.Find(id);
                if (cliente != null)
                {
                    ProductoCliente productoCliente = new ProductoCliente();
                    productoCliente.IdClienteNavigation = cliente;
                    productoCliente.IdCliente = cliente.Id;
                    productoCliente.IdProducto = producto.Id;
                    productoCliente.IdProductoNavigation = producto;
                    _context.ProductoClientes.Add(productoCliente);
                    _context.SaveChanges();
                    ProductoCliente pro = _context.ProductoClientes.OrderBy(o=>o.IdRelacion).Last();
                    producto.ProductoClientes.Append(pro);
                    cliente.ProductoClientes.Append(pro);
                    _context.Clientes.Update(cliente);
                    _context.Productos.Update(producto);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
           
        }*/

        [HttpPut]
        [Route("/cliente/agregarIngreso")]
        public async Task<IActionResult> agregarIngreso(int idIngreso, int idCliente)
        {
            Ingreso ingreso = await _context.Ingresos.FindAsync(idIngreso);
            Cliente cliente = await _context.Clientes.FindAsync(idCliente);

            if (ingreso != null && cliente != null)
            {
                IngresoCliente ingresoCliente = new IngresoCliente();

                ingresoCliente.IdIngresoNavigation = ingreso;
                ingresoCliente.IdClienteNavigation = cliente;

                await _context.IngresoClientes.AddAsync(ingresoCliente);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("/cliente")]
        public async Task<ActionResult<List<Cliente>>> getClientes()
        {
            try
            {
                return new OkObjectResult(_context.Clientes.ToList());
            }
            catch {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("/cliente/localidad")]
        public async Task<ActionResult<List<Cliente>>> getClientePorLocalidad(string localidad)
        {
            try
            {
                return new OkObjectResult(_context.Clientes.Where(o => o.Localidad.Equals(localidad)).ToList());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/cliente/{id}")]
        public async Task<ActionResult<Cliente>> getCliente(int id)
        {
            try
            {
                return new OkObjectResult(_context.Clientes.Find(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/cliente/agregar")]
        public async Task<IActionResult> postCliente(ClienteDto dto)
        {
            try
            {

                Cliente cliente = new Cliente(); 
                cliente.Localidad = dto.Localidad;
                cliente.Nombre= dto.Nombre;
                cliente.Estado = 1;
                _context.Clientes.Add(cliente);
                Console.Write("hola");
                _context.SaveChanges();
                return Ok();
            } catch
            
            {
                return NotFound();
            }
        }




    }
}
