using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for DepartmentEmployee class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentEmployeeController : Controller
{
    private readonly ILogger<DepartmentEmployeeController> _logger;
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the DepartmentEmployeeController
    /// </summary>
    public DepartmentEmployeeController(OrganizationRepository organizationRepository, IMapper mapper,
        ILogger<DepartmentEmployeeController> logger)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the connections between Department and Employee
    /// </summary>
    /// <returns>All the connections between Department and Employee in the organization</returns>
    [HttpGet]
    public IEnumerable<GetDepartmentEmployeeDto> Get()
    {
        _logger.LogInformation("Get DepartmentEmployees");
        return _mapper.Map<IEnumerable<GetDepartmentEmployeeDto>>(_organizationRepository.DepartmentEmployees);
    }
    /// <summary>
    /// The method returns a DepartmentEmployee by ID
    /// </summary>
    /// <param name="id">DepartmentEmployee ID</param>
    /// <returns>DepartmentEmployee with the given ID or 404 code if DepartmentEmployee is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<GetDepartmentEmployeeDto> Get(int id)
    {
        _logger.LogInformation("Get DepartmentEmployee with id {id}", id);
        var departmentEmployee =
            _organizationRepository.DepartmentEmployees
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
    /// <returns>Code 200 and the added DepartmentEmployee is success; 404 code if department or employee is not found
    /// </returns>
    [HttpPost]
    public ActionResult<PostDepartmentEmployeeDto> Post([FromBody] PostDepartmentEmployeeDto departmentEmployee)
    {
        _logger.LogInformation("POST DepartmentEmployee method");
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployee>(departmentEmployee);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedDepartmentEmployee.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", mappedDepartmentEmployee.EmployeeId);
            return NotFound(string.Format("An employee with given id={0} doesn't exist",
                mappedDepartmentEmployee.EmployeeId));
        }
        var department =
            _organizationRepository.Departments
            .FirstOrDefault(department => department.Id == mappedDepartmentEmployee.DepartmentId);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found", mappedDepartmentEmployee.DepartmentId);
            return NotFound(string.Format("An department with given id={0} doesn't exist",
                mappedDepartmentEmployee.DepartmentId));
        }
        mappedDepartmentEmployee.Department = department;
        mappedDepartmentEmployee.Employee = employee;
        _organizationRepository.DepartmentEmployees.Add(mappedDepartmentEmployee);
        return Ok(departmentEmployee);
    }
    /// <summary>
    /// The method updates a DepartmentEmployee information by ID
    /// </summary>
    /// <param name="id">An ID of the DepartmentEmployee</param>
    /// <param name="newDepartmentEmployee">New information of the DepartmentEmployee</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public ActionResult<PostDepartmentEmployeeDto> Put(int id, [FromBody] PostDepartmentEmployeeDto newDepartmentEmployee)
    {
        _logger.LogInformation("PUT DepartmentEmployee method");
        var departmentEmployee = _organizationRepository
            .DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null)
        {
            _logger.LogInformation("The DepartmentEmployee with ID {id} is not found", id);
            return NotFound("The DepartmentEmployee with given id is not found");
        }
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployee>(newDepartmentEmployee);
        var employee =
                       _organizationRepository.Employees
                       .FirstOrDefault(employee => employee.Id == mappedDepartmentEmployee.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", mappedDepartmentEmployee.EmployeeId);
            return NotFound(string.Format("An employee with given id={0} doesn't exist",
                mappedDepartmentEmployee.EmployeeId));
        }
        var department =
                        _organizationRepository.Departments
                        .FirstOrDefault(department => department.Id == mappedDepartmentEmployee.DepartmentId);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found", mappedDepartmentEmployee.DepartmentId);
            return NotFound(string.Format("An department with given id={0} doesn't exist",
                mappedDepartmentEmployee.DepartmentId));
        }
        mappedDepartmentEmployee.Department = department;
        mappedDepartmentEmployee.Employee = employee;
        _organizationRepository.DepartmentEmployees.Remove(departmentEmployee);
        _organizationRepository.DepartmentEmployees.Add(mappedDepartmentEmployee);
        return Ok(newDepartmentEmployee);
    }
    /// <summary>
    /// The method deletes a DepartmentEmployee by ID
    /// </summary>
    /// <param name="id">An ID of the DepartmentEmployee</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<PostDepartmentEmployeeDto> Delete(int id)
    {
        _logger.LogInformation("DELETE DepartmentEmployee method with ID: {id}", id);
        var departmentEmployee = _organizationRepository.DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null)
        {
            _logger.LogInformation("The DepartmentEmployee with ID {id} is not found", id);
            return NotFound();
        }
        _organizationRepository.DepartmentEmployees.Remove(departmentEmployee);
        return Ok();
    }
}
