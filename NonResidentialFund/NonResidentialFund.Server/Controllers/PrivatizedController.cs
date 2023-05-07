using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Model;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrivatizedController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<PrivatizedController> _logger;
    private readonly IMapper _mapper;

    public PrivatizedController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<PrivatizedController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all privatized buildings
    /// </summary>
    /// <returns>List of prtivatized buildings</returns>
    [HttpGet]
    public async Task<IEnumerable<PrivatizedGetDto>> Get()
    {
        _logger.LogInformation("Get all privatized buildings");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<PrivatizedGetDto>>(ctx.Privatized);
    }

    /// <summary>
    /// Returns the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the privatized building</param>
    /// <returns>Result of operation and privatized building object</returns>
    [HttpGet("{registrationNumber}")]
    public async Task<ActionResult<PrivatizedGetDto>> Get(int registrationNumber)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var privatized = ctx.Privatized.FirstOrDefault(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get privatized building with registration number: {registrationNumber}", registrationNumber);
            return Ok(_mapper.Map<PrivatizedGetDto>(privatized));
        }
    }

    /// <summary>
    /// Creates new privatized building
    /// </summary>
    /// <param name="privatized">Privatized building to be created</param>
    [HttpPost]
    public async void Post([FromBody] PrivatizedPostDto privatized)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Privatized.Add(_mapper.Map<Privatized>(privatized));
        ctx.SaveChanges();
    }

    /// <summary>
    /// Changes the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the privatized building to be changed</param>
    /// <param name="privatizedToPut">New privatized building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public async Task<IActionResult> Put(int registrationNumber, [FromBody] PrivatizedPostDto privatizedToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var privatized = ctx.Privatized.FirstOrDefault(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            if (privatizedToPut.RegistrationNumber != privatized.RegistrationNumber)
            {
                return BadRequest();
            }
            ctx.Privatized.Update(_mapper.Map(privatizedToPut, privatized));
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Removes the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the privatized building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public async Task<IActionResult> Delete(int registrationNumber)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var privatized = ctx.Privatized.FirstOrDefault(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            ctx.Privatized.Remove(privatized);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
