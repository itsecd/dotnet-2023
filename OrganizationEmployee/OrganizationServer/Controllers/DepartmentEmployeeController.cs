using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;
using OrganizationEmployee.EmployeeDomain;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for DepartmentEmployee class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentEmployeeController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the DepartmentEmployeeController
    /// </summary>
    public DepartmentEmployeeController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// The method returns all the connections between Department and Employee
    /// </summary>
    /// <returns>All the connections between Department and Employee in the organization</returns>
    [HttpGet]
    public IEnumerable<DepartmentEmployeeDto> Get()
    {
        return _mapper.Map<IEnumerable<DepartmentEmployeeDto>>(_organizationRepository.DepartmentEmployees);
    }
    /// <summary>
    /// The method returns a DepartmentEmployee by ID
    /// </summary>
    /// <param name="id">DepartmentEmployee ID</param>
    /// <returns>DepartmentEmployee with the given ID or 404 code if DepartmentEmployee is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<DepartmentEmployeeDto> Get(int id)
    {
        var departmentEmployee =
            _organizationRepository.DepartmentEmployees
            .FirstOrDefault(departEmployee => departEmployee.Id == id);
        if (departmentEmployee == null) return NotFound();
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployeeDto>(departmentEmployee);
        return Ok(mappedDepartmentEmployee);
    }
    /// <summary>
    /// The method adds a new DepartmentEmployee into organization
    /// </summary>
    /// <param name="departmentEmployee">A new DepartmentEmployee that need to be added</param>
    /// <returns>Code 200 and the added DepartmentEmployee is success; 404 code if department or employee is not found
    /// </returns>
    [HttpPost]
    public ActionResult<DepartmentEmployeeDto> Post([FromBody] DepartmentEmployeeDto departmentEmployee)
    {
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployee>(departmentEmployee);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedDepartmentEmployee.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var department =
            _organizationRepository.Departments
            .FirstOrDefault(department => department.Id == mappedDepartmentEmployee.DepartmentId);
        if (department == null) return NotFound("A department with given id doesn't exist");
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
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpPut("{id}")]
    public ActionResult<DepartmentEmployeeDto> Put(int id, [FromBody] DepartmentEmployeeDto newDepartmentEmployee)
    {
        var departmentEmployee = _organizationRepository
            .DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null) return NotFound();
        var mappedDepartmentEmployee = _mapper.Map<DepartmentEmployee>(newDepartmentEmployee);
        var employee =
                       _organizationRepository.Employees
                       .FirstOrDefault(employee => employee.Id == mappedDepartmentEmployee.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var department =
                        _organizationRepository.Departments
                        .FirstOrDefault(department => department.Id == mappedDepartmentEmployee.DepartmentId);
        if (department == null) return NotFound("A department with given id doesn't exist");
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
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<DepartmentEmployeeDto> Delete(int id)
    {
        var departmentEmployee = _organizationRepository.DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null) return NotFound();
        _organizationRepository.DepartmentEmployees.Remove(departmentEmployee);
        return Ok();
    }
}
