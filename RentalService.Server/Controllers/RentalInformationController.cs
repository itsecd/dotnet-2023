using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for rental information table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalInformationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly RentalServiceDbContext _context;

    public RentalInformationController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all rental information
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentalInformation>>> Get()
    {
        //return _rentalServiceRepository.RentalInformations;
        if (_context.RentalInformations == null)
        {
            return NotFound();
        }
        return await _context.RentalInformations.ToListAsync();
    }

    /// <summary>
    ///     Get method which returns rental information by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentalInformation>> Get(ulong id)
    {
        /*RentalInformation? rentalInformation =
            _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation($"Not found rentalInformation: {id}");
            return NotFound();
        }

        return Ok(rentalInformation);*/
        if (_context.RentalInformations == null)
        {
            return NotFound();
        }
        var rentalInformation = await _context.RentalInformations.FindAsync(id);

        if (rentalInformation == null)
        {
            return NotFound();
        }

        return Ok(rentalInformation);
    }

    /// <summary>
    ///     Post method which add new rental information
    /// </summary>
    [HttpPost]
    public async  Task<ActionResult<RentalInformation>> Post([FromBody] RentalInformationPostDto rentalInformation)
    {
        //_rentalServiceRepository.RentalInformations.Add(_mapper.Map<RentalInformation>(rentalInformation));
        if (_context.RentalInformations == null)
        {
            return Problem("Entity set 'DataBaseContext.RentalInformations'  is null.");
        }

        var mappedRentalInformation = _mapper.Map<RentalInformation>(rentalInformation);
        
        _context.RentalInformations.Add(mappedRentalInformation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedRentalInformation.Id },
            _mapper.Map<RentalInformation>(mappedRentalInformation));
    }

    /// <summary>
    ///     Put method for changing data in the rental information table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] RentalInformationPostDto rentalInformationToPut)
    {
        /*RentalInformation? rentalInformation =
            _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation("Not found rentalInformation: {id}", id);
            return NotFound();
        }

        _mapper.Map(rentalInformationToPut, rentalInformation);
        return Ok();*/
        if (_context.RentalInformations == null)
        {
            return NotFound();
        }
        
        var rentalInformationToModify = await _context.RentalInformations.FindAsync(id);

        if (rentalInformationToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(rentalInformationToPut, rentalInformationToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a rental information
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        /*RentalInformation? rentalInformation =
            _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation($"Not found rentalInformation: {id}");
            return NotFound();
        }

        _rentalServiceRepository.RentalInformations.Remove(rentalInformation);
        return Ok();*/
        if (_context.RentalInformations == null)
        {
            return NotFound();
        }
        var rentalInformation = await _context.RentalInformations.FindAsync(id);
        if (rentalInformation == null)
        {
            return NotFound();
        }

        _context.RentalInformations.Remove(rentalInformation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}