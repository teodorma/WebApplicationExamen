using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class UtilizatoriController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UtilizatoriController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Utilizator>>> GetUtilizatori()
    {
        return await _context.Utilizatori.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Utilizator>> GetUtilizator(int id)
    {
        var utilizator = await _context.Utilizatori.FindAsync(id);

        if (utilizator == null)
        {
            return NotFound();
        }

        return utilizator;
    }

    [HttpPost]
    public async Task<ActionResult<Utilizator>> PostUtilizator(Utilizator utilizator)
    {
        _context.Utilizatori.Add(utilizator);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUtilizator", new { id = utilizator.UtilizatorId }, utilizator);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUtilizator(int id, Utilizator utilizator)
    {
        if (id != utilizator.UtilizatorId)
        {
            return BadRequest();
        }

        _context.Entry(utilizator).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Utilizatori.Any(e => e.UtilizatorId == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilizator(int id)
    {
        var utilizator = await _context.Utilizatori.FindAsync(id);
        if (utilizator == null)
        {
            return NotFound();
        }

        _context.Utilizatori.Remove(utilizator);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
