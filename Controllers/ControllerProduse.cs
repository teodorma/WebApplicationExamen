using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

[Route("api/[controller]")]
[ApiController]
public class ProduseController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProduseController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Produse
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produs>>> GetProduse()
    {
        return await _context.Produse.ToListAsync();
    }

    // GET: api/Produse/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Produs>> GetProdus(int id)
    {
        var produs = await _context.Produse.FindAsync(id);

        if (produs == null)
        {
            return NotFound();
        }

        return produs;
    }

    // POST: api/Produse
    [HttpPost]
    public async Task<ActionResult<Produs>> PostProdus(Produs produs)
    {
        _context.Produse.Add(produs);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProdus", new { id = produs.ProdusId }, produs);
    }

    // PUT: api/Produse/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProdus(int id, Produs produs)
    {
        if (id != produs.ProdusId)
        {
            return BadRequest();
        }

        _context.Entry(produs).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Produse.Any(e => e.ProdusId == id))
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

    // DELETE: api/Produse/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProdus(int id)
    {
        var produs = await _context.Produse.FindAsync(id);
        if (produs == null)
        {
            return NotFound();
        }

        _context.Produse.Remove(produs);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
