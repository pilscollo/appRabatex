using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using ProyectoRabatexOficial.Dto;
using ProyectoRabatexOficial.Models;

namespace ProyectoRabatexOficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgresoController : ControllerBase
    {
        public DbProyectoRabatexContext _context;

        public EgresoController(DbProyectoRabatexContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route ("/egreso/{Id}")]
        public async Task<ActionResult<Egreso>> GetEgreso(int Id) {
            try {

                return new OkObjectResult(_context.Egresos.Find(Id));
            } catch {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/egreso")]
        public async Task<ActionResult<List<Egreso>>> Getegresos()
        {
            try
            {

                return new OkObjectResult(_context.Egresos.OrderBy(o=>o.Fecha).ToList());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/Egreso/tipo")]

        public async Task<ActionResult<List<Egreso>>> getEgresoPorTipo(string tipo)
        {
            try
            {
                List<Egreso> listaResultado= new List<Egreso>();
                listaResultado = _context.Egresos.Where(o => o.Tipo.Equals(tipo)).ToList();
                return new OkObjectResult(listaResultado.OrderBy(o => o.Fecha).ToList());
            }
            catch
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        [Route("egreso/agregar")]
        public async Task<IActionResult> PostEgreso(EgresoDto dto)
        {
            try
            {
                Egreso egreso = new Egreso();
                egreso.Estado = 1;
                egreso.Fecha = dto.Fecha;
                egreso.Monto = dto.Monto;
                egreso.Tipo = dto.Tipo;
                
                
                
                await _context.Egresos.AddAsync(egreso);
                

                _context.SaveChanges();
                return Ok();

            }
            catch
            { return NotFound(); }

        }
        
    }
}

