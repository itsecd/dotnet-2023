using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.Dto;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeOccupationController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public EmployeeOccupationController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<EmployeeOccupationDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<EmployeeOccupationDto>>(_organizationRepository.EmployeeOccupations);
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeOccupationDto> Get(int id)
    {
        var employeeOccupation =
            _organizationRepository.EmployeeOccupations
            .FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null) return NotFound();
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupationDto>(employeeOccupation);
        return Ok(mappedEmployeeOccupation);
    }

    [HttpPost]
    public ActionResult<EmployeeOccupationDto> Post([FromBody] EmployeeOccupationDto employeeOccupation)
    {
        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupation>(employeeOccupation);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeOccupation.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var occupation =
            _organizationRepository.Occupations
            .FirstOrDefault(occupation => occupation.Id == mappedEmployeeOccupation.OccupationId);
        if (occupation == null) return NotFound("An occupation with given id doesn't exist");
        mappedEmployeeOccupation.Occupation = occupation;
        mappedEmployeeOccupation.Employee = employee;
        _organizationRepository.EmployeeOccupations.Add(mappedEmployeeOccupation);
        return Ok(employeeOccupation);
    }


    [HttpPut("{id}")]
    public ActionResult<EmployeeOccupationDto> Put(int id, [FromBody] EmployeeOccupationDto newEmployeeOccupation)
    {
        var employeeOccupation = _organizationRepository
            .EmployeeOccupations.FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null) return NotFound();

        var mappedEmployeeOccupation = _mapper.Map<EmployeeOccupation>(newEmployeeOccupation);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeOccupation.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var occupation =
            _organizationRepository.Occupations
            .FirstOrDefault(occupation => occupation.Id == mappedEmployeeOccupation.OccupationId);
        if (occupation == null) return NotFound("An occupation with given id doesn't exist");
        mappedEmployeeOccupation.Occupation = occupation;
        mappedEmployeeOccupation.Employee = employee;
        _organizationRepository.EmployeeOccupations.Remove(employeeOccupation);
        _organizationRepository.EmployeeOccupations.Add(mappedEmployeeOccupation);
        return Ok(newEmployeeOccupation);
    }

    [HttpDelete("{id}")]
    public ActionResult<EmployeeOccupationDto> Delete(int id)
    {
        var employeeOccupation =
            _organizationRepository.EmployeeOccupations
            .FirstOrDefault(employeeOccupation => employeeOccupation.Id == id);
        if (employeeOccupation == null) return NotFound();
        _organizationRepository.EmployeeOccupations.Remove(employeeOccupation);
        return Ok();
    }
}
