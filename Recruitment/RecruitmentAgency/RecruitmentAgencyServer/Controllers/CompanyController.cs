using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
/// Controller for companies
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ILogger<CompanyController> _logger;
    private readonly IDbContextFactory<RecruitmentAgencyContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public CompanyController(ILogger<CompanyController> logger, IDbContextFactory<RecruitmentAgencyContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all companies
    /// </summary>
    /// <returns>Returns a list of all companies</returns>
    [HttpGet]
    public async Task<IEnumerable<CompanyGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get companies");
        var companies = await ctx.Companies.ToListAsync();
        return _mapper.Map<IEnumerable<CompanyGetDto>>(companies);
    }
    /// <summary>
    ///  Get method that returns a company with a specific id
    /// </summary>
    /// <param name="id">Company id</param>
    /// <returns>Company with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get company with id {id}");
        var company = ctx.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null)
        {
            _logger.LogInformation("Not found company with id equals to: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<CompanyGetDto>(company));
    }

    /// <summary>
    /// Post method that adding a new company 
    /// </summary>
    /// <param name="company">Company data</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<CompanyGetDto>> Post([FromBody] CompanyPostDto company)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post company");
        await ctx.Companies.AddAsync(_mapper.Map<Company>(company));
        await ctx.SaveChangesAsync();
        var mappedCompany = _mapper.Map<CompanyGetDto>(company);
        return CreatedAtAction("Post", new { id = mappedCompany.Id },
            _mapper.Map<CompanyGetDto>(mappedCompany));
    }

    /// <summary>
    /// Put method which allows change the data of a company with a specific id
    /// </summary>
    /// <param name="id">Company id</param>
    /// <param name="companyToPut">Company data</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CompanyPostDto companyToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put company with id {id}", id);
        var company = ctx.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null)
        {
            _logger.LogInformation("Not found company with id {id}", id);
            return NotFound();
        }
        ctx.Update(_mapper.Map(companyToPut, company));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Delete method which allows delete a company with a specific id
    /// </summary>
    /// <param name="id">Company id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Delete company with id ({id})", id);
        var company = ctx.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null)
        {
            _logger.LogInformation("Not found company with id ({id})", id);
            return NotFound();
        }
        ctx.Companies.Remove(company);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
