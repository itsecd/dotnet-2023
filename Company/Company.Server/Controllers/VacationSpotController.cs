using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for VacationSpots of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VacationSpotController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<VacationSpotController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the VacationSpotController
    /// </summary>
    public VacationSpotController(IMapper mapper, ILogger<VacationSpotController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all VacationSpots in the Company
    /// </summary>
    /// <returns>All VacationSpots in the Company</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VacationSpotGetDto>>> GetVacationSpots()
    {
        if (_context.VacationSpotDb == null)
        {
            _logger.LogInformation("VacationSpots database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<VacationSpotGetDto>(_context.VacationSpotDb).ToListAsync();
    }


    /// <summary>
    /// Method returns VacationSpot by id
    /// </summary>
    /// <param name="id">Id of VacationSpot</param>
    /// <returns>VacationSpot with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VacationSpotGetDto>> GetVacationSpot(int id)
    {
        if (_context.VacationSpotDb == null)
        {
            _logger.LogInformation("VacationSpots database is empty");
            return NotFound();
        }
        var vacationSpot = await _context.VacationSpotDb.FindAsync(id);
        if (vacationSpot == null)
        {
            _logger.LogInformation("The VacationSpot with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<VacationSpotGetDto>(vacationSpot);
    }


    /// <summary>
    /// Method updates VacationSpot information by id
    /// </summary>
    /// <param name="id">Id of VacationSpot</param>
    /// <param name="vacationSpot">New information about VacationSpot</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVacationSpot(int id, VacationSpotPostDto vacationSpot)
    {
        if (_context.VacationSpotDb == null)
        {
            _logger.LogInformation("VacationSpots database is empty");
            return NotFound();
        }
        var vacationSpotToModify = await _context.VacationSpotDb.FindAsync(id);
        if (vacationSpotToModify == null)
        {
            _logger.LogInformation("The VacationSpot with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(vacationSpot, vacationSpotToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds VacationSpot in Company
    /// </summary>
    /// <param name="vacationSpot">New VacationSpot</param>
    /// <returns>Added VacationSpot and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<VacationSpotGetDto>> PostVacationSpot(VacationSpotPostDto vacationSpot)
    {
        if (_context.VacationSpotDb == null)
        {
            _logger.LogInformation("VacationSpots database is empty");
            return NotFound();
        }
        var mappedVacationSpot = _mapper.Map<VacationSpot>(vacationSpot);

        _context.VacationSpotDb.Add(mappedVacationSpot);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostVacationSpot", new { id = mappedVacationSpot.Id }, _mapper.Map<VacationSpotGetDto>(mappedVacationSpot));
    }


    /// <summary>
    /// Method deletes VacationSpot by id
    /// </summary>
    /// <param name="id">Id of VacationSpot</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVacationSpot(int id)
    {
        if (_context.VacationSpotDb == null)
        {
            _logger.LogInformation("VacationSpots database is empty");
            return NotFound();
        }
        var vacationSpot = await _context.VacationSpotDb.FindAsync(id);
        if (vacationSpot == null)
        {
            _logger.LogInformation("The VacationSpot with Id {id} is not found", id);
            return NotFound();
        }

        _context.VacationSpotDb.Remove(vacationSpot);
        await _context.SaveChangesAsync();

        return Ok();
    }
}