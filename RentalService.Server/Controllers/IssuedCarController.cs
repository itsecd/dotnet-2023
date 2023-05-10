using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for issued car table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class IssuedCarController : ControllerBase
{
    private readonly RentalServiceDbContext _context;
    private readonly IMapper _mapper;

    public IssuedCarController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all issued cars
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IssuedCar>>> Get()
    {
        if (_context.IssuedCars == null)
        {
            return NotFound();
        }

        return await _context.IssuedCars.ToListAsync();
    }

    /// <summary>
    ///     Get method which returns issued car by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<IssuedCar>> Get(ulong id)
    {
        if (_context.IssuedCars == null)
        {
            return NotFound();
        }

        IssuedCar? issuedCar = await _context.IssuedCars.FindAsync(id);

        if (issuedCar == null)
        {
            return NotFound();
        }

        return Ok(issuedCar);
    }

    /// <summary>
    ///     Post method which add new issued car
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<IssuedCar>> Post([FromBody] IssuedCarPostDto issuedCar)
    {
        if (_context.IssuedCars == null)
        {
            return Problem("Entity set 'DataBaseContext.IssuedCars'  is null.");
        }

        IssuedCar? mappedIssuedCar = _mapper.Map<IssuedCar>(issuedCar);

        _context.IssuedCars.Add(mappedIssuedCar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedIssuedCar.Id }, _mapper.Map<IssuedCar>(mappedIssuedCar));
    }

    /// <summary>
    ///     Put method for changing data in the issued car table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] IssuedCarPostDto issuedCarToPut)
    {
        if (_context.IssuedCars == null)
        {
            return NotFound();
        }

        IssuedCar? issuedCarToModify = await _context.IssuedCars.FindAsync(id);

        if (issuedCarToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(issuedCarToPut, issuedCarToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a issued car
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        if (_context.IssuedCars == null)
        {
            return NotFound();
        }

        IssuedCar? issuedCar = await _context.IssuedCars.FindAsync(id);
        if (issuedCar == null)
        {
            return NotFound();
        }

        _context.IssuedCars.Remove(issuedCar);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}