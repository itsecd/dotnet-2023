using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.Dto;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentEmployeeController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public DepartmentEmployeeController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<DepartmentEmployeeDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<DepartmentEmployeeDto>>(_organizationRepository.DepartmentEmployees);
    }

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
        if (employee == null) return NotFound("A department with given id doesn't exist");
        mappedDepartmentEmployee.Department = department;
        mappedDepartmentEmployee.Employee = employee;
        _organizationRepository.DepartmentEmployees.Add(mappedDepartmentEmployee);
        return Ok(departmentEmployee);
    }


    [HttpPut("{id}")]
    public ActionResult<DepartmentEmployeeDto> Put(int id, [FromBody] DepartmentEmployee newDepartmentEmployee)
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
        if (employee == null) return NotFound("A department with given id doesn't exist");
        mappedDepartmentEmployee.Department = department;
        mappedDepartmentEmployee.Employee = employee;
        _organizationRepository.DepartmentEmployees.Remove(departmentEmployee);
        _organizationRepository.DepartmentEmployees.Add(mappedDepartmentEmployee);
        return Ok(newDepartmentEmployee);
    }

    [HttpDelete("{id}")]
    public ActionResult<DepartmentEmployeeDto> Delete(int id)
    {
        var departmentEmployee = _organizationRepository.DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null) return NotFound();
        _organizationRepository.DepartmentEmployees.Remove(departmentEmployee);
        return Ok();
    }
}
