using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace P01_2022MP653_2023GL651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SucursalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();
            return sucursal;
        }

        [HttpPost]
        public async Task<ActionResult<Sucursal>> CreateSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.Id }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.Id) return BadRequest();

            _context.Entry(sucursal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null) return NotFound();

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("reservados/{fecha}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorDia(DateTime fecha)
        {
            var reservas = await _context.Reservas
                .Where(r => r.Fecha == fecha)
                .ToListAsync();

            return reservas;
        }
       
        [HttpGet("reservados/{sucursalId}/{fechaInicio}/{fechaFin}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorRango(int sucursalId, DateTime fechaInicio, DateTime fechaFin)
        {
            var reservas = await _context.Reservas
                .Where(r => r.Fecha >= fechaInicio && r.Fecha <= fechaFin)
                .Join(_context.EspaciosParqueo,
                    reserva => reserva.EspacioId,
                    espacio => espacio.Id,
                    (reserva, espacio) => new { reserva, espacio })
                .Where(x => x.espacio.SucursalId == sucursalId)
                .Select(x => x.reserva)
                .ToListAsync();

            return reservas;
        }


    }
}