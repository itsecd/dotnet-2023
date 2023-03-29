using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

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
    public IEnumerable<DepartmentEmployee> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _organizationRepository.DepartmentEmployees;
    }

    [HttpGet("{id}")]
    public ActionResult<DepartmentEmployee> Get(int id)
    {
        var departmentEmployee =
            _organizationRepository.DepartmentEmployees
            .FirstOrDefault(departEmployee => departEmployee.Id == id);
        if (departmentEmployee == null) return NotFound();
        return Ok(departmentEmployee);
    }

    [HttpPost]
    public ActionResult<DepartmentEmployee> Post([FromBody] DepartmentEmployeeDTO departmentEmployee)
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
        return Ok(mappedDepartmentEmployee);
    }


    [HttpPut("{id}")]
    public ActionResult<DepartmentEmployee> Put(int id, [FromBody] DepartmentEmployee newDepartmentEmployee)
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
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<Department> Delete(int id)
    {
        var departmentEmployee = _organizationRepository.DepartmentEmployees.FirstOrDefault(departmentEmployee => departmentEmployee.Id == id);
        if (departmentEmployee == null) return NotFound();
        _organizationRepository.DepartmentEmployees.Remove(departmentEmployee);
        return Ok();
    }
}
