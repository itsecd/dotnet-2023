using Fabrics.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipmentsController : ControllerBase
{
    private readonly FabricsDbContext _context;

    public ShipmentsController(FabricsDbContext context)
    {
        _context = context;
    }

    // GET: api/Shipments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
    {
        if (_context.Shipments == null)
        {
            return NotFound();
        }
        return await _context.Shipments.ToListAsync();
    }

    // GET: api/Shipments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Shipment>> GetShipment(int id)
    {
        if (_context.Shipments == null)
        {
            return NotFound();
        }
        var shipment = await _context.Shipments.FindAsync(id);

        if (shipment == null)
        {
            return NotFound();
        }

        return shipment;
    }

    // PUT: api/Shipments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutShipment(int id, Shipment shipment)
    {
        if (id != shipment.Id)
        {
            return BadRequest();
        }

        _context.Entry(shipment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ShipmentExists(id))
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

    // POST: api/Shipments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
    {
        if (_context.Shipments == null)
        {
            return Problem("Entity set 'FabricsDbContext.Shipments'  is null.");
        }
        _context.Shipments.Add(shipment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetShipment", new { id = shipment.Id }, shipment);
    }

    // DELETE: api/Shipments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShipment(int id)
    {
        if (_context.Shipments == null)
        {
            return NotFound();
        }
        var shipment = await _context.Shipments.FindAsync(id);
        if (shipment == null)
        {
            return NotFound();
        }

        _context.Shipments.Remove(shipment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ShipmentExists(int id)
    {
        return (_context.Shipments?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
