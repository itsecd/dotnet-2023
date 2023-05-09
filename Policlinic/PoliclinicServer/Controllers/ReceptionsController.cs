using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policlinic;
using PoliclinicServer.Dto;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Receptions controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ReceptionsController : ControllerBase
{
    private readonly PoliclinicDbContext _context;

    private readonly IMapper _mapper;
    /// <summary>
    /// ReceptionsController constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public ReceptionsController(PoliclinicDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all receptions
    /// </summary>
    /// <returns>List of all receptions</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReceptionDto>>> GetReceptions()
    {
        if (_context.Receptions == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ReceptionDto>(_context.Receptions).ToListAsync();
    }

    /// <summary>
    /// Get reception with given id
    /// </summary>
    /// <param name="id">Reception's id</param>
    /// <returns>Reception</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReceptionDto>> GetReception(int id)
    {
        if (_context.Receptions == null)
        {
            return NotFound();
        }
        var reception = await _context.Receptions.FindAsync(id);

        if (reception == null)
        {
            return NotFound();
        }

        return _mapper.Map<ReceptionDto>(reception);
    }

    /// <summary>
    /// Change data about reception
    /// </summary>
    /// <param name="id">Reception's id</param>
    /// <param name="reception">Changeable reception</param>
    /// <returns>The result of the operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReception(int id, ReceptionDto reception)
    {
        if (_context.Receptions == null)
        {
            return NotFound();
        }

        var receptionToModify = await _context.Receptions.FindAsync(id);
        if (receptionToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(reception, receptionToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Add new reception
    /// </summary>
    /// <param name="reception">Reception</param>
    /// <returns>Created reception</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ReceptionDto>> PostReception(ReceptionDto reception)
    {
        if (_context.Receptions == null)
        {
            return Problem("Entity set 'PoliclinicDbContext.Receptions' is null.");
        }
        var mappedReception = _mapper.Map<Reception>(reception);
        _context.Receptions.Add(mappedReception);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostReception", new { id = mappedReception.Id }, _mapper.Map<ReceptionDto>(mappedReception));
    }

    /// <summary>
    /// Deletion a reception
    /// </summary>
    /// <param name="id">Reception's id</param>
    /// <returns>The result of the operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReception(int id)
    {
        if (_context.Receptions == null)
        {
            return NotFound();
        }
        var reception = await _context.Receptions.FindAsync(id);
        if (reception == null)
        {
            return NotFound();
        }

        _context.Receptions.Remove(reception);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
