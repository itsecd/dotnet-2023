using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Domain;

namespace BikeRental.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeTypesController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    public BikeTypesController(BikeRentalDbContext context)
    {
        _context = context;
    }

    // GET: api/BikeTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BikeType>>> GetBikeTypes()
    {
      if (_context.BikeTypes == null)
      {
          return NotFound();
      }
        return await _context.BikeTypes.ToListAsync();
    }

    // GET: api/BikeTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BikeType>> GetBikeType(int id)
    {
      if (_context.BikeTypes == null)
      {
          return NotFound();
      }
        var bikeType = await _context.BikeTypes.FindAsync(id);

        if (bikeType == null)
        {
            return NotFound();
        }

        return bikeType;
    }

    // PUT: api/BikeTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBikeType(int id, BikeType bikeType)
    {
        if (id != bikeType.Id)
        {
            return BadRequest();
        }

        _context.Entry(bikeType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BikeTypeExists(id))
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

    // POST: api/BikeTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<BikeType>> PostBikeType(BikeType bikeType)
    {
      if (_context.BikeTypes == null)
      {
          return Problem("Entity set 'BikeRentalDbContext.BikeTypes'  is null.");
      }
        _context.BikeTypes.Add(bikeType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBikeType", new { id = bikeType.Id }, bikeType);
    }

    // DELETE: api/BikeTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBikeType(int id)
    {
        if (_context.BikeTypes == null)
        {
            return NotFound();
        }
        var bikeType = await _context.BikeTypes.FindAsync(id);
        if (bikeType == null)
        {
            return NotFound();
        }

        _context.BikeTypes.Remove(bikeType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BikeTypeExists(int id)
    {
        return (_context.BikeTypes?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
