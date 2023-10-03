using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for Vacation of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VacationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<VacationController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the VacationController
    /// </summary>
    public VacationController(IMapper mapper, ILogger<VacationController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all Vacations in the Company
    /// </summary>
    /// <returns>All Vacations in the Company</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VacationGetDto>>> GetVacations()
    {
        if (_context.VacationDb == null)
        {
            _logger.LogInformation("Vacations database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<VacationGetDto>(_context.VacationDb).ToListAsync();
    }


    /// <summary>
    /// Method returns Vacation by id
    /// </summary>
    /// <param name="id">Id of Vacation</param>
    /// <returns>Vacation with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VacationGetDto>> GetVacation(int id)
    {
        if (_context.VacationDb == null)
        {
            _logger.LogInformation("Vacations database is empty");
            return NotFound();
        }
        var vacation = await _context.VacationDb.FindAsync(id);
        if (vacation == null)
        {
            _logger.LogInformation("The Vacation with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<VacationGetDto>(vacation);
    }


    /// <summary>
    /// Method updates Vacation information by id
    /// </summary>
    /// <param name="id">Id of Vacation</param>
    /// <param name="vacation">New information about Vacation</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVacation(int id, VacationPostDto vacation)
    {
        if (_context.VacationDb == null)
        {
            _logger.LogInformation("Vacations database is empty");
            return NotFound();
        }
        var vacationToModify = await _context.VacationDb.FindAsync(id);
        if (vacationToModify == null)
        {
            _logger.LogInformation("The Vacation with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(vacation, vacationToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds Vacation in Company
    /// </summary>
    /// <param name="vacation">New Vacation</param>
    /// <returns>Added Vacation and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<VacationGetDto>> PostVacation(VacationPostDto vacation)
    {
        if (_context.VacationDb == null)
        {
            _logger.LogInformation("Vacations database is empty");
            return NotFound();
        }
        var mappedVacation = _mapper.Map<Vacation>(vacation);

        _context.VacationDb.Add(mappedVacation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostVacation", new { id = mappedVacation.Id }, _mapper.Map<VacationGetDto>(mappedVacation));
    }


    /// <summary>
    /// Method deletes Vacation by id
    /// </summary>
    /// <param name="id">Id of Vacation</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVacation(int id)
    {
        if (_context.VacationDb == null)
        {
            _logger.LogInformation("Vacations database is empty");
            return NotFound();
        }
        var vacation = await _context.VacationDb.FindAsync(id);
        if (vacation == null)
        {
            _logger.LogInformation("The Vacation with Id {id} is not found", id);
            return NotFound();
        }

        _context.VacationDb.Remove(vacation);
        await _context.SaveChangesAsync();

        return Ok();
    }
}