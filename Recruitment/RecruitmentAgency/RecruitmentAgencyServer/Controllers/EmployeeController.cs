using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
///     Controller for employees
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IDbContextFactory<RecruitmentAgencyContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public EmployeeController(ILogger<EmployeeController> logger, IDbContextFactory<RecruitmentAgencyContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all employees
    /// </summary>
    /// <returns>Returns a list of all employees</returns>
    [HttpGet]
    public async Task<IEnumerable<EmployeeGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get employees");
        var employees = _mapper.Map<IEnumerable<EmployeeGetDto>>(await ctx.Employees.ToListAsync());
        return employees;
    }
    /// <summary>
    ///  Get method that returns an employee with a specific id
    /// </summary>
    /// <param name="id">Employee id</param>
    /// <returns>Employee with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeGetDto>> Get(int id)
    {

        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get employee with id {id}");
        var employee = ctx.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null)
        {
            _logger.LogInformation("Not found employee with id equals to: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<EmployeeGetDto>(employee));
    }
    /// <summary>
    /// Post method that adding a new employee
    /// </summary>
    /// <param name="employee">Employee data</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<EmployeeGetDto>> Post([FromBody] EmployeePostDto employee)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post employee");

        await ctx.Employees.AddAsync(_mapper.Map<Employee>(employee));
        await ctx.SaveChangesAsync();

        var newEmployee = await ctx.Employees
            .OrderByDescending(e => e.Id)
            .FirstOrDefaultAsync();

        var mappedEmployee = _mapper.Map<EmployeeGetDto>(newEmployee);

        return CreatedAtAction("Post", new { id = mappedEmployee.Id }, mappedEmployee);
    }

    /// <summary>
    /// Put method which allows change the data of an employee with a specific id
    /// </summary>
    /// <param name="id">Employee id</param>
    /// <param name="employeeToPut">Employee data</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EmployeePostDto employeeToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put employee with id {id}", id);
        var employee = ctx.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null)
        {
            _logger.LogInformation("Not found employee with id {id}", id);
            return NotFound();
        }
        ctx.Update(_mapper.Map(employeeToPut, employee));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete an employee with a specific id
    /// </summary>
    /// <param name="id">Employee id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Delete employee with id ({id})", id);
        var employee = ctx.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null)
        {
            _logger.LogInformation("Not found employee with id ({id})", id);
            return NotFound();
        }
        ctx.Employees.Remove(employee);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
