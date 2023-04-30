using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Book specializations controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationsController : ControllerBase
{
    private readonly ILogger<SpecializationsController> _logger;
    private readonly IDbContextFactory<PolyclinicDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public SpecializationsController(ILogger<SpecializationsController> logger, IDbContextFactory<PolyclinicDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get specializations
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<SpecializationsGetDto> Get()
    {
        _logger.LogInformation("Get Specializations");
        using var ctx = _contextFactory.CreateDbContext();
        return _mapper.Map<IEnumerable<SpecializationsGetDto>>(ctx.Specializations);
    }

    /// <summary>
    /// Get specialization by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecializationsGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var specialization = await ctx.FindAsync<Specializations>(id);
        if (specialization == null)
        {
            _logger.LogInformation($"Not found speciaization: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialization with id {id}");
            return Ok((_mapper.Map<SpecializationsGetDto>(specialization)));
        }
    }

}
