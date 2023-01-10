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
                    producto.Stock = 0;
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
        [HttpPost]
        [Route("/producto/agregar")]
        public async Task<IActionResult> PostProducto(ProductoDto dto)
        {
            try
            {
               Producto producto = new Producto();

                
                if (!dto.Nombre.Equals(""))
                {
                    producto.Nombre = dto.Nombre;
                    producto.Estado = 1;
                    producto.Stock = 0;
                    producto.Unidad = dto.Unidad;

                    _context.Productos.Add(producto);
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
                return new BadRequestResult();
            }
        }
    }
}

