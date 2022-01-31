using BackTarjetitas.Data;
using BackTarjetitas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackTarjetitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TarjetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<TarjetaCredito> listTarjetas = new List<TarjetaCredito>();
                listTarjetas = await _context.TarjetaCredito.ToListAsync();
                return Ok(listTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post( TarjetaCredito tarjeta)
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if(id != tarjeta.Id)
                {
                    return NotFound();
                }
                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "tarjeta actualizada con exito" });

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjetaToDelete = await _context.TarjetaCredito.FindAsync(id);
                if(tarjetaToDelete == null)
                {
                    return NotFound();
                }
                _context.TarjetaCredito.Remove(tarjetaToDelete);
                await _context.SaveChangesAsync();
                return Ok(new {message = "tarjeta borrada"});

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
