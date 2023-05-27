using AutoMapper;
using Organization.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for Employee of an organization
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the EmployeeController
    /// </summary>
    public EmployeeController(IDbContextFactory<EmployeeDbContext> сontextFactory, IMapper mapper,
        ILogger<EmployeeController> logger)
    {
        _contextFactory = сontextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the employee in the organization
    /// </summary>
    /// <returns>All the employee in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetEmployeeDto>> Get()
    {
        _logger.LogInformation("Get employees");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetEmployeeDto>>(ctx.Employees);
    }
    /// <summary>
    /// The method returns an employee by ID
    /// </summary>
    /// <param name="id">Employee ID</param>
    /// <returns>Employee with the given ID or 404 code if employee is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetEmployeeDto>> Get(uint id)
    {
        _logger.LogInformation("Get employee with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employee = ctx.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", id);
            return NotFound();
        }
        var mappedEmployee = _mapper.Map<GetEmployeeDto>(employee);
        return Ok(mappedEmployee);
    }
    /// <summary>
    /// The method adds a new employee into organization
    /// </summary>
    /// <param name="employee">A new employee that needs to be added</param>
    /// <returns>Code 200 and the added employee class if success; 
    /// 404 code if a workshop is not found;
    /// 409 code if an employee with same RegNumber already exists</returns>
    [HttpPost]
    public async Task<ActionResult<PostEmployeeDto>> Post([FromBody] PostEmployeeDto employee)
    {
        _logger.LogInformation("POST employee method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedEmployee = _mapper.Map<Employee>(employee);
        var workshop =
               ctx.Workshops.FirstOrDefault(workshop => workshop.Id == mappedEmployee.WorkshopId);
        var employeeWithRegNumber = ctx.Employees
            .FirstOrDefault(employee => employee.RegNumber == mappedEmployee.RegNumber);
        if (employeeWithRegNumber != null)
        {
            _logger.LogInformation("The employee with regNumber {regNumb} already exists",
                employee.RegNumber);
            return Conflict("An employee with given registration number already exists");
        }
        if (workshop == null)
        {
            _logger.LogInformation("The workshop with ID {id} is not found", employee.WorkshopId);
            return NotFound("A workshop with given id doesn't exist");
        }
        ctx.Employees.Add(mappedEmployee);
        await ctx.SaveChangesAsync();
        return Ok(employee);
    }
    /// <summary>
    /// The method updates an employee's information by ID
    /// </summary>
    /// <param name="id">An ID of the employee</param>
    /// <param name="newEmployee">New information of the employee</param>
    /// <returns>Code 200 and the updated employee class if success; 
    /// 404 code if a workshop is not found;
    /// 409 code if an employee with same RegNumber and different ID already exists</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<PostEmployeeDto>> Put(uint id, [FromBody] PostEmployeeDto newEmployee)
    {
        _logger.LogInformation("PUT employee method with ID: {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employee = ctx.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", id);
            return NotFound($"Employee with ID {id} doesn't exist");
        }
        var workshop =
            ctx.Workshops.FirstOrDefault(workshop => workshop.Id == newEmployee.WorkshopId);
        if (workshop == null)
        {
            _logger.LogInformation("The workshop with ID {id} is not found", employee.WorkshopId);
            return NotFound("A workshop with given id doesn't exist");
        }
        var mappedEmployee = _mapper.Map<Employee>(newEmployee);

        var employeeWithRegNumber = ctx.Employees.FirstOrDefault(
            employee => (employee.RegNumber == mappedEmployee.RegNumber
                          && employee.Id != id));
        if (employeeWithRegNumber != null)
        {
            _logger.LogInformation("The employee with regNumber {regNumb} already exists", employee.RegNumber);
            return Conflict("An employee with given registration number already exists");
        }
        ctx.Employees.Update(_mapper.Map(newEmployee, employee));
        await ctx.SaveChangesAsync();
        return Ok(newEmployee);
    }
    /// <summary>
    /// The method deletes an employee by ID
    /// </summary>
    /// <param name="id">An ID of the employee</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<PostEmployeeDto>> Delete(uint id)
    {
        _logger.LogInformation("DELETE employee method with ID: {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employee = ctx.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", id);
            return NotFound();
        }
        ctx.Employees.Remove(employee);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
