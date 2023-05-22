using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Domain;
using AutoMapper;
using BikeRental.Server.Dto;

namespace BikeRental.Server.Controllers;

/// <summary>
/// Clients
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentRecordsController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for RentRecordsController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public RentRecordsController(BikeRentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// View all rent records
    /// </summary>
    /// <returns>Rent record list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentRecordGetDto>>> GetRentRecords()
    {
      if (_context.RentRecords == null)
      { 
          return NotFound();
      }
        return await _mapper.ProjectTo<RentRecordGetDto>(_context.RentRecords).ToListAsync();
    }

    /// <summary>
    /// View rent record by id
    /// </summary>
    /// <param name="id">Record id</param>
    /// <returns>Record</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentRecordGetDto>> GetRentRecord(int id)
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

        return _mapper.Map<RentRecordGetDto>(rentRecord);
    }

    /// <summary>
    /// Change record info
    /// </summary>
    /// <param name="id">Record id</param>
    /// <param name="rentRecord">Changing record</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRentRecord(int id, RentRecordSetDto rentRecord)
    {
        if (_context.RentRecords == null)
        {
            return NotFound();
        }
        var recordToModify = await _context.RentRecords.FindAsync(id);
        if (recordToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(rentRecord, recordToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new rent record
    /// </summary>
    /// <param name="rentRecord">Rent record</param>
    /// <returns>Added rent record</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<RentRecordGetDto>> PostRentRecord(RentRecordSetDto rentRecord)
    {
      if (_context.RentRecords == null)
      {
          return Problem("Entity set 'BikeRentalDbContext.RentRecords'  is null.");
      }
        var mappedRecord = _mapper.Map<RentRecord>(rentRecord);

        _context.RentRecords.Add(mappedRecord);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostRentRecord", new { id = mappedRecord.Id }, _mapper.Map<RentRecordGetDto>(mappedRecord));
    }

    /// <summary>
    /// Deleting a rent record
    /// </summary>
    /// <param name="id">Deleted rent record id</param>
    /// <returns>Action result</returns>
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
}
