using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policlinic;
using PoliclinicServer.Dto;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Specializations
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationsController : ControllerBase
{
    private readonly PoliclinicDbContext _context;

    private readonly IMapper _mapper;
    /// <summary>
    /// SpecializationsController constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public SpecializationsController(PoliclinicDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all specializations
    /// </summary>
    /// <returns>List of all specializations</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SpecializationDto>>> GetSpecializations()
    {
        if (_context.Specializations == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<SpecializationDto>(_context.Specializations).ToListAsync();
    }

    /// <summary>
    /// Get specialization with given id
    /// </summary>
    /// <param name="id">Specialization's id</param>
    /// <returns>Specialization</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecializationDto>> GetSpecialization(int id)
    {
        if (_context.Specializations == null)
        {
            return NotFound();
        }
        var specialization = await _context.Specializations.FindAsync(id);

        if (specialization == null)
        {
            return NotFound();
        }

        return _mapper.Map<SpecializationDto>(specialization);
    }
}

