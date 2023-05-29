using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Domain;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for DepartmentEmployee class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentEmployeeController : Controller
{
    private readonly ILogger<DepartmentEmployeeController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the DepartmentEmployeeController
    /// </summary>
    public DepartmentEmployeeController(IDbContextFactory<EmployeeDbContext> contextFactory, IMapper mapper,
        ILogger<DepartmentEmployeeController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the connections between Department and Employee
    /// </summary>
    /// <returns>All the connections between Department and Employee in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetDepartmentEmployeeDto>> Get()
    {
        _logger.LogInformation("Get DepartmentEmployees");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetDepartmentEmployeeDto>>(ctx.DepartmentEmployees);
    }
    /// <summary>
    /// The method returns a DepartmentEmployee by ID
    /// </summary>
    /// <param name="id">DepartmentEmployee ID</param>
    /// <returns>DepartmentEmployee with the given ID or 404 code if DepartmentEmployee is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetDepartmentEmployeeDto>> Get(int id)
    {
        _logger.LogInformation("Get DepartmentEmployee with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var departmentEmployee =
            ctx.DepartmentEmployees
            .FirstOrDefault(departEmployee => departEmployee.Id == id);
        if (departmentEmployee == null)
        {
            _logger.LogInformation("The DepartmentEmployee with ID {id} is not found", id);
            return NotFound();
        }
        var mappedDepartmentEmployee = _mapper.Map<GetDepartmentEmployeeDto>(departmentEmployee);
        return Ok(mappedDepartmentEmployee);
    }
    /// <summary>
    /// The method adds a new DepartmentEmployee into organization
    /// </summary>
    /// <param name="departmentEmployee">A new DepartmentEmployee that need to be added</param>
    /// <returns>Code 201 and the added DepartmentEmployee is success; 404 code if department or employee is not found
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(GetDepartmentEmployeeDto), 201)]
    public async Task<ActionResult<GetDepartmentEmployeeDto>> Post([FromBody] PostDepartmentEmployeeDto departmentEmployee)
    {
        _logger.LogInformation("POST DepartmentEmployee method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployee>(departmentEmployee);
        var employee =
            ctx.Employees
            .FirstOrDefault(employee => employee.Id == mappedDepartmentEmployee.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found",
                mappedDepartmentEmployee.EmployeeId);
            return NotFound($"An employee with given id={mappedDepartmentEmployee.EmployeeId} doesn't exist");
        }
        var department =
            ctx.Departments
            .FirstOrDefault(department => department.Id == mappedDepartmentEmployee.DepartmentId);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found",
                mappedDepartmentEmployee.DepartmentId);
            return NotFound($"An department with given id={mappedDepartmentEmployee.DepartmentId} doesn't exist");
        }
        mappedDepartmentEmployee.Department = department;
        mappedDepartmentEmployee.Employee = employee;
        ctx.DepartmentEmployees.Add(mappedDepartmentEmployee);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("POST", _mapper.Map<GetDepartmentEmployeeDto>(mappedDepartmentEmployee));
    }
    /// <summary>
    /// The method updates a DepartmentEmployee information by ID
    /// </summary>
    /// <param name="id">An ID of the DepartmentEmployee</param>
    /// <param name="newDepartmentEmployee">New information of the DepartmentEmployee</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GetDepartmentEmployeeDto>> Put
        (int id, [FromBody] PostDepartmentEmployeeDto newDepartmentEmployee)
    {
        _logger.LogInformation("PUT DepartmentEmployee method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var departmentEmployee = ctx
            .DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null)
        {
            _logger.LogInformation("The DepartmentEmployee with ID {id} is not found", id);
            return NotFound("The DepartmentEmployee with given id is not found");
        }
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployee>(newDepartmentEmployee);
        var employee =
                       ctx.Employees
                       .FirstOrDefault(employee => employee.Id == mappedDepartmentEmployee.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", mappedDepartmentEmployee.EmployeeId);
            return NotFound($"An employee with given id={mappedDepartmentEmployee.EmployeeId} doesn't exist");
        }
        var department =
                        ctx.Departments
                        .FirstOrDefault(department => department.Id == mappedDepartmentEmployee.DepartmentId);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found", mappedDepartmentEmployee.DepartmentId);
            return NotFound($"An department with given id={mappedDepartmentEmployee.DepartmentId} doesn't exist");
        }
        ctx.DepartmentEmployees.Update(_mapper.Map(newDepartmentEmployee, departmentEmployee));
        await ctx.SaveChangesAsync();
        return Ok(_mapper.Map<GetDepartmentEmployeeDto>(mappedDepartmentEmployee));
    }
    /// <summary>
    /// The method deletes a DepartmentEmployee by ID
    /// </summary>
    /// <param name="id">An ID of the DepartmentEmployee</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GetDepartmentEmployeeDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE DepartmentEmployee method with ID: {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var departmentEmployee = ctx.DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null)
        {
            _logger.LogInformation("The DepartmentEmployee with ID {id} is not found", id);
            return NotFound();
        }
        ctx.DepartmentEmployees.Remove(departmentEmployee);
        await ctx.SaveChangesAsync();
        return Ok(_mapper.Map<GetDepartmentEmployeeDto>(departmentEmployee));
    }
}
