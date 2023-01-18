using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoRabatexOficial.Dto;
using ProyectoRabatexOficial.Models;

namespace ProyectoRabatexOficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : ControllerBase
    {
        public DbProyectoRabatexContext _context;

        public IngresoController(DbProyectoRabatexContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route ("/ingreso/idProducto/{Id}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(int Id) {
            try {

                return new OkObjectResult(_context.Ingresos.Find(Id));
            } catch {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/ingreso")]
        public async Task<ActionResult<List<Ingreso>>> GetIngresos()
        {
            try
            {

                return new OkObjectResult(_context.Ingresos.OrderBy(o=>o.Fecha).ToList());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/ingreso/{IdCliente}")]

        public async Task<ActionResult<List<Ingreso>>> getIngresoPorCliente(int IdCliente)
        {
            try
            {
                List<IngresoCliente> ingresoClientes = _context.IngresoClientes.ToList();
                List<Ingreso> listaResultado = new List<Ingreso>();
                foreach (IngresoCliente p in ingresoClientes)
                {
                    if (p.IdCliente == IdCliente)
                    {
                        listaResultado.Add(await _context.Ingresos.FindAsync(p.IdIngreso));
                    }
                }
                return new OkObjectResult(listaResultado.OrderBy(o => o.Fecha).ToList());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/ingreso/agregarProducto")]
        public async Task<IActionResult> PutIngreso( IngresoProductoDto dto)
        {

            try {
                Ingreso ingreso = _context.Ingresos.Find(dto.IdIngreso);
                Producto producto = _context.Productos.Find(dto.IdProducto);
                if (ingreso != null && producto != null && ingreso.Estado != 0 && producto.Estado != 0)
                {
                    IngresoProducto ingresoProducto = new IngresoProducto();
                    ingresoProducto.IdProducto = dto.IdProducto;
                    ingresoProducto.IdIngreso = dto.IdIngreso;
                    ingresoProducto.cantidad=dto.cantidad;
                    _context.IngresoProductos.Add(ingresoProducto);
                    _context.SaveChanges();

                    return Ok();
                }
                else
                { return NotFound(); 
                }
                 }
            catch { return NotFound(); }
        }
        
        [HttpPost]
        [Route("/ingreso/{IdCliente}")]
        public async Task<IActionResult> PostIngreso(int IdCliente,IngresoDto dto)
        {
            Console.WriteLine("hola");
            try
            {
                Ingreso ingreso = new Ingreso();
                ingreso.Estado = 1;
                ingreso.Fecha = dto.Fecha;
                ingreso.Monto = dto.Monto;
                ingreso.Detalle = dto.Detalle;
                IngresoCliente ingresoCliente = new IngresoCliente();
                
                await _context.Ingresos.AddAsync(ingreso);
               
                _context.SaveChanges();
                
                Ingreso UltimoIngreso = _context.Ingresos.OrderBy(o => o.Id).LastOrDefault();
                int id = -1;
                if (UltimoIngreso != null)
                {
                    id = UltimoIngreso.Id;
                    Console.WriteLine(id);

                }
                Console.WriteLine(id);



                Console.WriteLine(id);
                ingresoCliente.IdIngreso = id;
                ingresoCliente.IdCliente = IdCliente;
                await _context.IngresoClientes.AddAsync(ingresoCliente);
                _context.SaveChanges();
                return Ok();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
                
             }

        }
        
    }
}

