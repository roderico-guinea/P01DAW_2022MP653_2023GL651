using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022MP653_2023GL651.Models;

[Route("api/[controller]")]
[ApiController]
public class EspaciosParqueoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EspaciosParqueoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("disponibles/{fecha}")]
    public async Task<ActionResult<IEnumerable<EspacioParqueo>>> GetEspaciosDisponibles(DateTime fecha)
    {
        var espaciosDisponibles = await _context.EspaciosParqueo
            .Where(e => e.Estado == "Disponible")
            .ToListAsync();

        return espaciosDisponibles;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EspacioParqueo>>> GetEspaciosParqueo()
    {
        return await _context.EspaciosParqueo.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EspacioParqueo>> GetEspacioParqueo(int id)
    {
        var espacio = await _context.EspaciosParqueo.FindAsync(id);
        if (espacio == null) return NotFound();
        return espacio;
    }

    [HttpPost]
    public async Task<ActionResult<EspacioParqueo>> CreateEspacioParqueo(EspacioParqueo espacio)
    {
        _context.EspaciosParqueo.Add(espacio);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEspacioParqueo), new { id = espacio.Id }, espacio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEspacioParqueo(int id, EspacioParqueo espacio)
    {
        if (id != espacio.Id) return BadRequest();

        _context.Entry(espacio).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEspacioParqueo(int id)
    {
        var espacio = await _context.EspaciosParqueo.FindAsync(id);
        if (espacio == null) return NotFound();

        _context.EspaciosParqueo.Remove(espacio);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}