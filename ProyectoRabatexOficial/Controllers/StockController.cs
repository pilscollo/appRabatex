using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using ProyectoRabatexOficial.Dto;
using ProyectoRabatexOficial.Models;

namespace ProyectoRabatexOficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public DbProyectoRabatexContext _context;

        public StockController(DbProyectoRabatexContext context)
        { 
            _context=context;
        }

        [HttpGet]
        [Route("/stock")]
        public async Task<ActionResult<List<Stock>>> getStock()
        {
            try
            {
                return new OkObjectResult(_context.Stocks.ToList());
            }catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/stock/{idProducto}")]
        public async Task<ActionResult<List<Stock>>> getStockporProducto(int idProducto)
        {
            try
            {
                List<StockProducto> lista = _context.StockProductos.ToList();

                List<Stock> listaOfi = new List<Stock>();

                foreach(StockProducto p in lista)
                {
                    if (p.IdProducto == idProducto)
                    {
                        listaOfi.Add(await _context.Stocks.FindAsync(p.IdStock));
                    }
                }
                return new OkObjectResult(listaOfi);
    
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/stock/agregar/{idProducto}")]

        public async Task<IActionResult> agregarStock(int idProducto,StockDto dto)
        {/*
            try
            {
                Producto producto = await _context.Productos.FindAsync(idProducto);
                Stock stock1 = new Stock();
                stock1.Cantidad = dto.Cantidad;
                stock1.Costo = dto.Costo;
                stock1.Estado = 1;
                StockProducto stockProducto = new StockProducto();
                stockProducto.IdProductoNavigation = producto;
                stockProducto.IdStockNavigation = stock1;
                await _context.Stocks.AddAsync(stock1);
                await _context.StockProductos.AddAsync(stockProducto);

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e){ return NotFound(e.InnerException.Message); }*/

            try
            {
                
                StockProducto stockProducto = new StockProducto();
                Producto producto = await _context.Productos.FindAsync(idProducto);
                if (producto != null)
                {


                         
                    Stock stock1 = new Stock();
                    stock1.Cantidad = dto.Cantidad;
                    stock1.Costo = dto.Costo;
                    stock1.Estado = 1;
                    
                    await _context.Stocks.AddAsync(stock1);

                    _context.SaveChanges();
                    stockProducto.IdProducto = idProducto;
                    Stock  aux= _context.Stocks.OrderBy(o => o.Id).LastOrDefault();
                    if (aux != null)
                    {
                        stockProducto.IdStock = aux.Id;
                    }
                    else
                    {
                        stockProducto.IdStock = 0;
                    }

                    await _context.StockProductos.AddAsync(stockProducto);

                    _context.SaveChanges();
                    
                    
                   

                    return Ok();

                }
            
                else
                {
                    Console.WriteLine("chau");
                    return NotFound();
                }


                }
                catch(Exception e) {
                   

                    return NotFound(e.Message);
                }

            }
        [HttpPost]
        [Route("/stock/agregar/porNombre/{nombre}")]

        public async Task<IActionResult> agregarStockPorNombre(string nombre, StockDto dto)
        {/*
            try
            {
                Producto producto = await _context.Productos.FindAsync(idProducto);
                Stock stock1 = new Stock();
                stock1.Cantidad = dto.Cantidad;
                stock1.Costo = dto.Costo;
                stock1.Estado = 1;
                StockProducto stockProducto = new StockProducto();
                stockProducto.IdProductoNavigation = producto;
                stockProducto.IdStockNavigation = stock1;
                await _context.Stocks.AddAsync(stock1);
                await _context.StockProductos.AddAsync(stockProducto);

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e){ return NotFound(e.InnerException.Message); }*/

            try
            {

                StockProducto stockProducto = new StockProducto();
                Producto producto = _context.Productos.Where(o=>o.Nombre.Equals(nombre)).FirstOrDefault();
                if (producto != null)
                {



                    Stock stock1 = new Stock();
                    stock1.Cantidad = dto.Cantidad;
                    stock1.Costo = dto.Costo;
                    stock1.Estado = 1;

                    await _context.Stocks.AddAsync(stock1);

                    _context.SaveChanges();
                    stockProducto.IdProducto = producto.Id;
                    Stock aux = _context.Stocks.OrderBy(o => o.Id).LastOrDefault();
                    if (aux != null)
                    {
                        stockProducto.IdStock = aux.Id;
                    }
                    else
                    {
                        stockProducto.IdStock = 0;
                    }
                    await _context.StockProductos.AddAsync(stockProducto);
                    _context.SaveChanges();
                    return Ok();
                }

                else
                {
                    Console.WriteLine("chau");
                    return NotFound();
                }


            }
            catch (Exception e)
            {


                return NotFound(e.Message);
            }

        }
    }

    

}

