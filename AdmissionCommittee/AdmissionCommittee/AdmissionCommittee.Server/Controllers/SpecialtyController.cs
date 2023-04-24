using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    private readonly ILogger<SpecialtyController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public SpecialtyController(ILogger<SpecialtyController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Specialties
    /// </summary>
    /// <returns> IEnumerable type Specialty </returns>
    [HttpGet]
    public async Task<IEnumerable<SpecialtyGetDto>> Get()
    {
        _logger.LogInformation("Get all Specialties");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var specialties = await ctx.Specialties.ToArrayAsync();
        return _mapper.Map<IEnumerable<SpecialtyGetDto>>(specialties);
    }

    /// <summary>
    /// Get Specialty by id
    /// </summary>
    /// <param name="idSpecialty">id Speciality</param>
    /// <returns>Ok with SpecialtyGetDto or NotFound</returns>
    [HttpGet("{idSpecialty}")]
    public async Task<ActionResult<SpecialtyGetDto>> Get(int idSpecialty)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var specialty = await ctx.Specialties.FirstOrDefaultAsync(specialty => specialty.IdSpecialty == idSpecialty);
        if (specialty == null)
        {
            _logger.LogInformation("Not found Specialty : {idSpecialty}", idSpecialty);
            return NotFound($"The Specialty does't exist by this idSpecialty {idSpecialty}");
        }
        else
        {
            _logger.LogInformation("Get Specialty by {idSpecialty}", idSpecialty);
            return Ok(_mapper.Map<SpecialtyGetDto>(specialty));
        }
    }

    /// <summary>
    /// Create new Specialty
    /// </summary>
    /// <param name="specialty">new Specialty</param>
    [HttpPost]
    public async Task Post([FromBody] SpecialtyPostDto specialty)
    {
        _logger.LogInformation("Create new Specialty");
        var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Specialties.AddAsync(_mapper.Map<Specialty>(specialty));
        await ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Update information about Specialty
    /// </summary>
    /// <param name="idSpecialty">id Specialty</param>
    /// <param name="specialtyToPut">Specialty that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idSpecialty}")]
    public async Task<IActionResult> Put(int idSpecialty, [FromBody] SpecialtyPostDto specialtyToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var specialty = await ctx.Specialties.FirstOrDefaultAsync(specialty => specialty.IdSpecialty == idSpecialty);
        if (specialty == null)
        {
            _logger.LogInformation("Not found Specialty : {idSpecialty}", idSpecialty);
            return NotFound($"The Specialty does't exist by this id {idSpecialty}");
        }
        else
        {
            _logger.LogInformation("Update Specialty by id {idSpecialty}", idSpecialty);
            _mapper.Map(specialtyToPut, specialty);
            ctx.Specialties.Update(_mapper.Map<Specialty>(specialty));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Specialty
    /// </summary>
    /// <param name="idSpecialty">id Specialty for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idSpecialty}")]
    public async Task<IActionResult> Delete(int idSpecialty)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var specialty = await ctx.Specialties.Include(specialty => specialty.StatementSpecialties)
                                             .FirstOrDefaultAsync(specialty => specialty.IdSpecialty == idSpecialty);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found Specialty : {idSpecialty}");
            return NotFound($"The Specialty does't exist by this id {idSpecialty}");
        }
        else
        {
            _logger.LogInformation("Delete Specialty by id {idSpecialty}", idSpecialty);
            return Ok();
        }
    }
}