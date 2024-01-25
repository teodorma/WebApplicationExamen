using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class ComenziController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ComenziController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Comenzi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comanda>>> GetComenzi()
    {
        return await _context.Comenzi.ToListAsync();
    }

    // GET: api/Comenzi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Comanda>> GetComanda(int id)
    {
        var comanda = await _context.Comenzi.FindAsync(id);

        if (comanda == null)
        {
            return NotFound();
        }

        return comanda;
    }

    // POST: api/Comenzi
    [HttpPost]
    public async Task<ActionResult<Comanda>> PostComanda(Comanda comanda)
    {
        _context.Comenzi.Add(comanda);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetComanda", new { id = comanda.ComandaId }, comanda);
    }

    // PUT: api/Comenzi/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutComanda(int id, Comanda comanda)
    {
        if (id != comanda.ComandaId)
        {
            return BadRequest();
        }

        _context.Entry(comanda).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Comenzi.Any(e => e.ComandaId == id))
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

    // DELETE: api/Comenzi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComanda(int id)
    {
        var comanda = await _context.Comenzi.FindAsync(id);
        if (comanda == null)
        {
            return NotFound();
        }

        _context.Comenzi.Remove(comanda);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
