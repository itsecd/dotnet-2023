using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public EmployeeController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Employee> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _organizationRepository.Employees;
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(Guid id)
    {
        var employee = _organizationRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public void Post([FromBody] EmployeeDTO employee)
    {
        var mappedEmployee = _mapper.Map<Employee>(employee);
        _organizationRepository.Employees.Add(mappedEmployee);
    }


    [HttpPut("{id}")]
    public ActionResult<Employee> Put(Guid id, [FromBody] EmployeeDTO newEmployee)
    {
        var employee = _organizationRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        _organizationRepository.Employees.Remove(employee);
        var mappedEmployee = _mapper.Map<Employee>(newEmployee);
        _organizationRepository.Employees.Add(mappedEmployee);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<Department> Delete(Guid id)
    {
        var employee = _organizationRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        _organizationRepository.Employees.Remove(employee);
        return Ok();
    }
}
