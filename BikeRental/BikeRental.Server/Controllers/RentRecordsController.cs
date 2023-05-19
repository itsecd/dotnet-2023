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
public class RentRecordsController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    public RentRecordsController(BikeRentalDbContext context)
    {
        _context = context;
    }

    // GET: api/RentRecords
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentRecord>>> GetRentRecords()
    {
      if (_context.RentRecords == null)
      {
          return NotFound();
      }
        return await _context.RentRecords.ToListAsync();
    }

    // GET: api/RentRecords/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RentRecord>> GetRentRecord(int id)
    {
      if (_context.RentRecords == null)
      {
          return NotFound();
      }
        var rentRecord = await _context.RentRecords.FindAsync(id);

        if (rentRecord == null)
        {
            return NotFound();
        }

        return rentRecord;
    }

    // PUT: api/RentRecords/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRentRecord(int id, RentRecord rentRecord)
    {
        if (id != rentRecord.Id)
        {
            return BadRequest();
        }

        _context.Entry(rentRecord).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RentRecordExists(id))
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

    // POST: api/RentRecords
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RentRecord>> PostRentRecord(RentRecord rentRecord)
    {
      if (_context.RentRecords == null)
      {
          return Problem("Entity set 'BikeRentalDbContext.RentRecords'  is null.");
      }
        _context.RentRecords.Add(rentRecord);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRentRecord", new { id = rentRecord.Id }, rentRecord);
    }

    // DELETE: api/RentRecords/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRentRecord(int id)
    {
        if (_context.RentRecords == null)
        {
            return NotFound();
        }
        var rentRecord = await _context.RentRecords.FindAsync(id);
        if (rentRecord == null)
        {
            return NotFound();
        }

        _context.RentRecords.Remove(rentRecord);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RentRecordExists(int id)
    {
        return (_context.RentRecords?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
