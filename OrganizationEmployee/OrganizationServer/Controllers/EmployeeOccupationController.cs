using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for EmployeeOccupation class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeOccupationController : Controller
{
    private readonly ILogger<EmployeeOccupationController> _logger;
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the EmployeeOccupationController
    /// </summary>
    public EmployeeOccupationController(OrganizationRepository organizationRepository, IMapper mapper,
        ILogger<EmployeeOccupationController> logger)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the connections between Employee and Occupation
    /// </summary>
    /// <returns>All the connections between Employee and Occupation in the organization</returns>
    [HttpGet]
    public IEnumerable<EmployeeOccupationDto> Get()
    {
        _logger.LogInformation("Get EmployeeOccupations");
        return _mapper.Map<IEnumerable<EmployeeOccupationDto>>(_organizationRepository.EmployeeOccupations);
    }
    /// <summary>
    /// The method returns a EmployeeOccupation by ID
    /// </summary>
    /// <param name="id">EmployeeOccupation ID</param>
    /// <returns>EmployeeOccupation with the given ID or 404 code if EmployeeOccupation is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployeeOccupationDto> Get(int id)
    {
        _logger.LogInformation("Get EmployeeOccupation with id {id}", id);
        var employeeOccupation =
            _organizationRepository.EmployeeOccupations
            .FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null)
        {
            _logger.LogInformation("The EmployeeOccupation with ID {id} is not found", id);
            return NotFound("The EmployeeOccupation with given id is not found");
        }
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupationDto>(employeeOccupation);
        return Ok(mappedEmployeeOccupation);
    }
    /// <summary>
    /// The method adds a new EmployeeOccupation into organization
    /// </summary>
    /// <param name="departmentEmployee">A new EmployeeOccupation that needs to be added</param>
    /// <returns>Code 200 and the added EmployeeOccupation is success; 404 code if department or occupation is not found
    /// </returns>
    [HttpPost]
    public ActionResult<EmployeeOccupationDto> Post([FromBody] EmployeeOccupationDto employeeOccupation)
    {
        _logger.LogInformation("POST EmployeeOccupation method");
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupation>(employeeOccupation);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeOccupation.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("An employee with id {id} doesn't exist", employeeOccupation.EmployeeId);
            return NotFound("An employee with given id doesn't exist");
        }
        var occupation =
            _organizationRepository.Occupations
            .FirstOrDefault(occupation => occupation.Id == mappedEmployeeOccupation.OccupationId);
        if (occupation == null)
        {
            _logger.LogInformation("An occupation with id {id} doesn't exist", employeeOccupation.OccupationId);
            return NotFound("An occupation with given id doesn't exist");
        }
        mappedEmployeeOccupation.Occupation = occupation;
        mappedEmployeeOccupation.Employee = employee;
        _organizationRepository.EmployeeOccupations.Add(mappedEmployeeOccupation);
        return Ok(employeeOccupation);
    }
    /// <summary>
    /// The method updates an EmployeeOccupation information by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeOccupation</param>
    /// <param name="newDepartmentEmployee">New information of the EmployeeOccupation</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpPut("{id}")]
    public ActionResult<EmployeeOccupationDto> Put(int id, [FromBody] EmployeeOccupationDto newEmployeeOccupation)
    {
        _logger.LogInformation("PUT EmployeeOccupation method");
        var employeeOccupation = _organizationRepository
            .EmployeeOccupations.FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null)
        {
            _logger.LogInformation("The EmployeeOccupation with ID {id} is not found", id);
            return NotFound("The EmployeeOccupation with given id is not found");
        }
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupation>(newEmployeeOccupation);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeOccupation.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("The employee with ID {id} is not found", mappedEmployeeOccupation.EmployeeId);
            return NotFound("An employee with given id doesn't exist");
        }
        var occupation =
            _organizationRepository.Occupations
            .FirstOrDefault(occupation => occupation.Id == mappedEmployeeOccupation.OccupationId);
        if (occupation == null)
        {
            _logger.LogInformation("The occupation with ID {id} is not found",
                mappedEmployeeOccupation.OccupationId);
            return NotFound("An occupation with given id doesn't exist");
        }
        mappedEmployeeOccupation.Occupation = occupation;
        mappedEmployeeOccupation.Employee = employee;
        _organizationRepository.EmployeeOccupations.Remove(employeeOccupation);
        _organizationRepository.EmployeeOccupations.Add(mappedEmployeeOccupation);
        return Ok(newEmployeeOccupation);
    }
    /// <summary>
    /// The method deletes a EmployeeOccupation by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeOccupation</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<EmployeeOccupationDto> Delete(int id)
    {
        _logger.LogInformation("DELETE EmployeeOccupation method");
        var employeeOccupation =
            _organizationRepository.EmployeeOccupations
            .FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null)
        {
            _logger.LogInformation("The EmployeeOccupation with ID {id} is not found", id);
            return NotFound();
        }
        _organizationRepository.EmployeeOccupations.Remove(employeeOccupation);
        return Ok();
    }
}
