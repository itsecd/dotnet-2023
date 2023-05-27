using AutoMapper;
using Organization.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for EmployeeOccupation class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeOccupationController : Controller
{
    private readonly ILogger<EmployeeOccupationController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the EmployeeOccupationController
    /// </summary>
    public EmployeeOccupationController(IDbContextFactory<EmployeeDbContext> contextFactory, IMapper mapper,
        ILogger<EmployeeOccupationController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the connections between Employee and Occupation
    /// </summary>
    /// <returns>All the connections between Employee and Occupation in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetEmployeeOccupationDto>> Get()
    {
        _logger.LogInformation("Get EmployeeOccupations");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetEmployeeOccupationDto>>(ctx.EmployeeOccupations);
    }
    /// <summary>
    /// The method returns a EmployeeOccupation by ID
    /// </summary>
    /// <param name="id">EmployeeOccupation ID</param>
    /// <returns>EmployeeOccupation with the given ID or 404 code if EmployeeOccupation is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetEmployeeOccupationDto>> Get(int id)
    {
        _logger.LogInformation("Get EmployeeOccupation with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeeOccupation =
            ctx.EmployeeOccupations
            .FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null)
        {
            _logger.LogInformation("The EmployeeOccupation with ID {id} is not found", id);
            return NotFound();
        }
        var mappedEmployeeOccupation = _mapper.Map<GetEmployeeOccupationDto>(employeeOccupation);
        return Ok(mappedEmployeeOccupation);
    }
    /// <summary>
    /// The method adds a new EmployeeOccupation into organization
    /// </summary>
    /// <param name="employeeOccupation">A new EmployeeOccupation that needs to be added</param>
    /// <returns>Code 200 and the added EmployeeOccupation is success; 404 code if department or occupation is not found
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<PostEmployeeOccupationDto>> Post
        ([FromBody] PostEmployeeOccupationDto employeeOccupation)
    {
        _logger.LogInformation("POST EmployeeOccupation method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupation>(employeeOccupation);
        var employee =
            ctx.Employees.FirstOrDefault(employee => employee.Id == mappedEmployeeOccupation.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("An employee with id {id} doesn't exist", employeeOccupation.EmployeeId);
            return NotFound("An employee with given id doesn't exist");
        }
        var occupation =
            ctx.Occupations.FirstOrDefault(occupation => occupation.Id == mappedEmployeeOccupation.OccupationId);
        if (occupation == null)
        {
            _logger.LogInformation("An occupation with id {id} doesn't exist", employeeOccupation.OccupationId);
            return NotFound("An occupation with given id doesn't exist");
        }
        mappedEmployeeOccupation.Occupation = occupation;
        mappedEmployeeOccupation.Employee = employee;
        ctx.EmployeeOccupations.Add(mappedEmployeeOccupation);
        await ctx.SaveChangesAsync();
        return Ok(employeeOccupation);
    }
    /// <summary>
    /// The method updates an EmployeeOccupation information by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeOccupation</param>
    /// <param name="newEmployeeOccupation">New information of the EmployeeOccupation</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<PostEmployeeOccupationDto>> Put
        (int id, [FromBody] PostEmployeeOccupationDto newEmployeeOccupation)
    {
        _logger.LogInformation("PUT EmployeeOccupation method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeeOccupation = ctx
            .EmployeeOccupations.FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null)
        {
            _logger.LogInformation("The EmployeeOccupation with ID {id} is not found", id);
            return NotFound("The EmployeeOccupation with given id is not found");
        }
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupation>(newEmployeeOccupation);
        var employee =
            ctx.Employees.FirstOrDefault(employee => employee.Id == mappedEmployeeOccupation.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", mappedEmployeeOccupation.EmployeeId);
            return NotFound("An employee with given id doesn't exist");
        }
        var occupation =
            ctx.Occupations.FirstOrDefault(occupation => occupation.Id == mappedEmployeeOccupation.OccupationId);
        if (occupation == null)
        {
            _logger.LogInformation("The occupation with ID {id} is not found",
                mappedEmployeeOccupation.OccupationId);
            return NotFound("An occupation with given id doesn't exist");
        }
        ctx.EmployeeOccupations.Update(_mapper.Map(newEmployeeOccupation, employeeOccupation));
        await ctx.SaveChangesAsync();
        return Ok(newEmployeeOccupation);
    }
    /// <summary>
    /// The method deletes a EmployeeOccupation by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeOccupation</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<PostEmployeeOccupationDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE EmployeeOccupation method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeeOccupation =
            ctx.EmployeeOccupations
            .FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null)
        {
            _logger.LogInformation("The EmployeeOccupation with ID {id} is not found", id);
            return NotFound();
        }
        ctx.EmployeeOccupations.Remove(employeeOccupation);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
