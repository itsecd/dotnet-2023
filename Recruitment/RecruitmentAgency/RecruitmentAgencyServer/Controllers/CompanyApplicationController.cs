using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
///     Controller for companies applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyApplicationController : ControllerBase
{
    private readonly ILogger<CompanyApplicationController> _logger;
    private readonly IDbContextFactory<RecruitmentAgencyContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public CompanyApplicationController(ILogger<CompanyApplicationController> logger, IDbContextFactory<RecruitmentAgencyContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all companies applications
    /// </summary>
    /// <returns>Returns a list of all companies applications</returns>
    [HttpGet]
    public async Task<IEnumerable<CompanyApplicationGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get companies applications");
        var companyApplications = _mapper.Map<IEnumerable<CompanyApplicationGetDto>>(await ctx.CompanyApplications.ToListAsync());
        return companyApplications;
    }
    /// <summary>
    ///  Get method that returns company application with a specific id
    /// </summary>
    /// <param name="id">Company application id</param>
    /// <returns>Company with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyApplicationGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get company applicaiton with id {id}");
        var companyApplication = ctx.CompanyApplications.FirstOrDefault(companyApplication => companyApplication.Id == id);
        if (companyApplication == null)
        {
            _logger.LogInformation("Not found company application with id equals to: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<CompanyApplicationGetDto>(companyApplication));
    }
    /// <summary>
    /// Post method that adding a new company application
    /// </summary>
    /// <param name="companyApplication"></param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyApplicationGetDto companyApplication)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post company application");
        await ctx.CompanyApplications.AddAsync(_mapper.Map<CompanyApplication>(companyApplication));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put method which allows change the data of company application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="companyApplicationToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CompanyApplicationGetDto companyApplicationToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put company application with id {id}", id);
        var companyApplication = ctx.CompanyApplications.FirstOrDefault(companyApplication => companyApplication.Id == id);
        if (companyApplication == null)
        {
            _logger.LogInformation("Not found company application with id {id}", id);
            return NotFound();
        }
        ctx.Update(_mapper.Map(companyApplicationToPut, companyApplication));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a company application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Delete company  application with id ({id})", id);
        var companyApplication = ctx.CompanyApplications.FirstOrDefault(companyApplication => companyApplication.Id == id);
        if (companyApplication == null)
        {
            _logger.LogInformation("Not found company application with id ({id})", id);
            return NotFound();
        }
        ctx.CompanyApplications.Remove(companyApplication);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
