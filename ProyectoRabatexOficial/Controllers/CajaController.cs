using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoRabatexOficial.Models;

namespace ProyectoRabatexOficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        public DbProyectoRabatexContext _context;

        public  CajaController(DbProyectoRabatexContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("/Caja/configurar")]
        public async Task<IActionResult> putCaja(int monto)
        {
            if (monto > 0)
            {
                Caja caja = new Caja();
                caja.Id = 0;
                caja.Monto = monto;
                _context.Cajas.Update(caja);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("/Caja")]

        public async Task<ActionResult<Caja>> getCaja()
        {
            Caja caja = _context.Cajas.FirstOrDefault();
            if (caja == null)
            {
                var aux = new Caja();
                aux.Monto = 0;
                await  _context.Cajas.AddAsync(aux);
                _context.SaveChanges();
                caja = _context.Cajas.FirstOrDefault();
            }
            
            return new OkObjectResult(caja); ;
            
        }
    }
}
