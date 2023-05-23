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

    private readonly ILogger _logger;

    public RentRecordsController(BikeRentalDbContext context, IMapper mapper, ILogger<RentRecordsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all rent records
    /// </summary>
    /// <returns>Rent record list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentRecordGetDto>>> GetRentRecords()
    {
        _logger.LogInformation("Get rent records list");
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
        _logger.LogInformation("Get rent record by id");
        if (_context.RentRecords == null)
        {
            return NotFound();
        }
        var rentRecord = await _context.RentRecords.FindAsync(id);

        if (rentRecord == null)
        {
            _logger.LogInformation("Rent record not found");
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
            _logger.LogInformation("Rent record not found");
            return NotFound();
        }

        _mapper.Map(rentRecord, recordToModify);

        _logger.LogInformation("Successfully updated");

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

        _logger.LogInformation("Successfully added");

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
            _logger.LogInformation("Rent record not found");
            return NotFound();
        }

        _context.RentRecords.Remove(rentRecord);

        _logger.LogInformation("Successfully deleted");

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
