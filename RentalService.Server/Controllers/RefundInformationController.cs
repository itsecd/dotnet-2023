using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for refund information table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RefundInformationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly RentalServiceDbContext _context;

    public RefundInformationController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all refund information
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RefundInformation>>> Get()
    {
        if (_context.RefundInformations == null)
        {
            return NotFound();
        }
        return await _context.RefundInformations.ToListAsync();
    }

    /// <summary>
    ///     Get method which returns refund information by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<RefundInformation>> Get(ulong id)
    {
        /*RefundInformation? refundInformation =
            _rentalServiceRepository.RefundInformations.FirstOrDefault(refundInformation => refundInformation.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation($"Not found refundInformation: {id}");
            return NotFound();
        }

        return Ok(refundInformation);*/
        if (_context.RefundInformations == null)
        {
            return NotFound();
        }
        var refundInformation = await _context.RefundInformations.FindAsync(id);

        if (refundInformation == null)
        {
            return NotFound();
        }

        return Ok(refundInformation);
    }

    /// <summary>
    ///     Post method which add new refund information
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<RefundInformation>> Post([FromBody] RefundInformationPostDto refundInformation)
    {
        //_rentalServiceRepository.RefundInformations.Add(_mapper.Map<RefundInformation>(refundInformation));
        if (_context.RefundInformations == null)
        {
            return Problem("Entity set 'DataBaseContext.RefundInformations'  is null.");
        }

        var mappedRefundInformation = _mapper.Map<RefundInformation>(refundInformation);
        
        _context.RefundInformations.Add(mappedRefundInformation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedRefundInformation.Id },
            _mapper.Map<RefundInformation>(mappedRefundInformation));
    }

    /// <summary>
    ///     Put method for changing data in the refund information table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] RefundInformationPostDto refundInformationToPut)
    {
        /*RefundInformation? refundInformation =
            _rentalServiceRepository.RefundInformations.FirstOrDefault(information => information.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation("Not found refundInformationToPut: {id}", id);
            return NotFound();
        }

        _mapper.Map(refundInformationToPut, refundInformation);
        return Ok();*/
        if (_context.RefundInformations == null)
        {
            return NotFound();
        }
        
        var refundInformationToModify = await _context.RefundInformations.FindAsync(id);

        if (refundInformationToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(refundInformationToPut, refundInformationToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a refund information
    /// </summary>
    [HttpDelete("{id}")]
    public  async Task<IActionResult> Delete(ulong id)
    {
        /*RefundInformation? refundInformation =
            _rentalServiceRepository.RefundInformations.FirstOrDefault(information => information.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation($"Not found refundInformation: {id}");
            return NotFound();
        }

        _rentalServiceRepository.RefundInformations.Remove(refundInformation);
        return Ok();*/
        if (_context.RefundInformations == null)
        {
            return NotFound();
        }
        var refundInformation = await _context.RefundInformations.FindAsync(id);
        if (refundInformation == null)
        {
            return NotFound();
        }

        _context.RefundInformations.Remove(refundInformation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}