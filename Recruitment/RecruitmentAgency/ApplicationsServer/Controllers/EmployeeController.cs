using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.Dto;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;

/// <summary>
///     Controller foremployees
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public EmployeeController(ILogger<EmployeeController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all employees
    /// </summary>
    /// <returns>Returns a list of all employees</returns>
    [HttpGet]
    public IEnumerable<EmployeeGetDto> Get()
    {
        _logger.LogInformation("Get employees");
        return _companiesRepository.Employees.Select(employee => _mapper.Map<EmployeeGetDto>(employee));
    }
    /// <summary>
    ///  Get method that returns an employee with a specific id
    /// </summary>
    /// <param name="id">Employee id</param>
    /// <returns>Employee with required id</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployeeGetDto> Get(int id)
    {
        _logger.LogInformation($"Get employee with id {id}");
        var employee = _companiesRepository.Employees.FirstOrDefault(employee => employee.Id == id);
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
    /// <param name="employee"></param>
    [HttpPost]
    public void Post([FromBody] EmployeePostDto employee)
    {
        _companiesRepository.Employees.Add(_mapper.Map<Employee>(employee));
     }

    /// <summary>
    /// Put method which allows change the data of an employee with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employeeToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmployeePostDto employeeToPut)
    {
        _logger.LogInformation($" Attempting to change an employee with an id equal to =  {id}");
        var employee = _companiesRepository.Companies.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete an employee with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($" Attempting to delete an employee with an id equal to =  {id}");
        var employee = _companiesRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        _companiesRepository.Employees.Remove(employee);
        return Ok();
    }
}
