using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoRabatexOficial.Dto;
using ProyectoRabatexOficial.Models;

namespace ProyectoRabatexOficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public DbProyectoRabatexContext _context;

        public ProductoController(DbProyectoRabatexContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("/producto/agregarStok/{Id}")]
        public async Task<IActionResult> putProductoStock(int Id,int stock)
        {
            try
            {
                Producto producto = _context.Productos.Find(Id);


                if (producto!=null)
                {


                    producto.Stock = stock;

                    _context.Productos.Update(producto);
                    _context.SaveChanges();

                    return Ok("todo ok");
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        [HttpPut]
        [Route("/producto/configurar")]
        public async Task<IActionResult> PutProducto(ProductoDto dto)
        {
            try
            {

                if (!dto.Nombre.Equals(""))
                {
                    Producto producto = _context.Productos.Where(o => o.Nombre.Equals(dto.Nombre)).FirstOrDefault();
                    producto.Nombre = dto.Nombre;
                    producto.Estado = 1;
                    producto.Unidad = dto.Unidad;

                    _context.Productos.Update(producto);
                    _context.SaveChanges();

                    return Ok("todo ok");
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new NotFoundResult();
            }
            }
        [HttpPut]
        [Route("/producto/activar/{Id}")]
        public async Task<IActionResult> activarProducto(int Id)
        {
            try
            {
                Producto producto = await _context.Productos.FindAsync(Id);
                if (producto != null)
                {
                    producto.Estado = 1;
                    producto.Id = Id;
                    Console.WriteLine(producto.Id);
                    _context.Productos.Update(producto);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }
        }
        [HttpPut]
        [Route("/productos/eliminar/{Id}")]
        public async Task<IActionResult> eliminarProducto(int Id)
        {
            try {
                Producto producto = await _context.Productos.FindAsync(Id);
                if (producto != null)
                {
                    Console.WriteLine("holaaaaaa");
                    producto.Estado = 0;
                    Console.WriteLine(producto.Id);
                    _context.Update(producto);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok();
            } catch {
                return NotFound();

            }
        }
        [HttpGet]
        [Route("/producto/activos")]
        public async Task<ActionResult<List<Producto>>> GetProductoActivos()
        {

            try
            {

                return new OkObjectResult(_context.Productos.Where(o=>o.Estado==1).ToList());
            }
            catch
            { return NotFound(); }
        }

        [HttpGet]
        [Route("/producto")]
        public async Task<ActionResult<List<Producto>>> GetProductoTodos()
        {

            try
            {

                return new OkObjectResult(_context.Productos.ToList());
            }
            catch
            { return NotFound(); }
        }
        [HttpGet]
        [Route("/producto/{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {

            try
            {

                return new OkObjectResult(_context.Productos.Find(id));
            }
            catch
            { return NotFound(); }
        }
        [HttpGet]
        [Route("/producto/nombre/{nombre}")]
        public async Task<ActionResult<Producto>> obtenerProducto(string nombre)
        {
            try
            {
                Producto producto= _context.Productos.Where(e => e.Nombre.Equals(nombre)).FirstOrDefault();
                if (producto != null)
                {
                    return new OkObjectResult(producto);
                }
                else { return NotFound(); }
            }
            catch
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Route("/producto/agregar")]
        public async Task<IActionResult> PostProducto(ProductoDto dto)
        {
            try
            {
               Producto producto = new Producto();

                
                if (!dto.Nombre.Equals("") || _context.Productos.Where(o=>o.Nombre.Equals(dto.Nombre)).FirstOrDefault()==null)
                {
                    producto.Nombre = dto.Nombre;
                    producto.Estado = 1;
                    producto.Stock = 0;
                    producto.Unidad = dto.Unidad;

                    await _context.Productos.AddAsync(producto);
                    _context.SaveChanges();

                    return Ok("todo ok");
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

