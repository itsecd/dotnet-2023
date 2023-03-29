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
    public ActionResult<Department> Get(int id)
    {
        var department = _organizationRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null) return NotFound();
        return Ok(department);
    }

    [HttpPost]
    public void Post([FromBody] DepartmentDTO department)
    {
        var mappedDepartment = _mapper.Map<Department>(department);
        _organizationRepository.Departments.Add(mappedDepartment);
    }


    [HttpPut("{id}")]
    public ActionResult<Department> Put(int id, [FromBody] DepartmentDTO newDepartment)
    {
        var department = _organizationRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null) return NotFound();
        _organizationRepository.Departments.Remove(department);
        var mappedDepartment = _mapper.Map<Department>(newDepartment);
        _organizationRepository.Departments.Add(mappedDepartment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<Department> Delete(int id)
    {
        var department = _organizationRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null) return NotFound();
        _organizationRepository.Departments.Remove(department);
        return Ok();
    }
}
