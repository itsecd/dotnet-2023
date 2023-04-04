using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;
using OrganizationEmployee.EmployeeDomain;

namespace OrganizationEmployee.OrganizationServer.Controllers;
/// <summary>
/// Controller for Department of an organization
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the DepartmentController
    /// </summary>
    public DepartmentController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// The method returns all the departments in the organization
    /// </summary>
    /// <returns>All the departments in the organization</returns>
    [HttpGet]
    public IEnumerable<Department> Get()
    {
        return _organizationRepository.Departments;
    }
    /// <summary>
    /// The method returns a department by ID
    /// </summary>
    /// <param name="id">Department ID</param>
    /// <returns>Department with the given ID or 404 code if department is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<Department> Get(int id)
    {
        var department = _organizationRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null) return NotFound();
        return Ok(department);
    }
    /// <summary>
    /// The method adds a new department into organization
    /// </summary>
    /// <param name="department">A new department that need to be added</param>
    [HttpPost]
    public void Post([FromBody] DepartmentDto department)
    {
        var mappedDepartment = _mapper.Map<Department>(department);
        _organizationRepository.Departments.Add(mappedDepartment);
    }
    /// <summary>
    /// The method updates a department information by ID
    /// </summary>
    /// <param name="id">An ID of the department</param>
    /// <param name="newDepartment">New information of the department</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpPut("{id}")]
    public ActionResult<Department> Put(int id, [FromBody] DepartmentDto newDepartment)
    {
        var department = _organizationRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null) return NotFound();
        _organizationRepository.Departments.Remove(department);
        var mappedDepartment = _mapper.Map<Department>(newDepartment);
        _organizationRepository.Departments.Add(mappedDepartment);
        return Ok();
    }
    /// <summary>
    /// The method deletes a department by ID
    /// </summary>
    /// <param name="id">An ID of the department</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<Department> Delete(int id)
    {
        var department = _organizationRepository.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null) return NotFound();
        _organizationRepository.Departments.Remove(department);
        return Ok();
    }
}
