using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;
using System.Collections.Generic;

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
    public IEnumerable<EmployeeDTO> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<EmployeeDTO>>(_organizationRepository.Employees);
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeDTO> Get(uint id)
    {
        var employee = _organizationRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        var mappedEmployee = _mapper.Map<EmployeeDTO>(employee);
        return Ok(mappedEmployee);
    }

    [HttpPost]
    public ActionResult<EmployeeDTO> Post([FromBody] EmployeeDTO employee)
    {
        var mappedEmployee = _mapper.Map<Employee>(employee);
        var workshop =
               _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == mappedEmployee.WorkshopId);
        if (workshop == null) return NotFound("A workshop with given id doesn't exist");
        _organizationRepository.Employees.Add(mappedEmployee);
        return Ok(employee);
    }


    [HttpPut("{id}")]
    public ActionResult<EmployeeDTO> Put(uint id, [FromBody] EmployeeDTO newEmployee)
    {
        var employee = _organizationRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        var workshop =
       _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == newEmployee.WorkshopId);
        if (workshop == null) return NotFound("A workshop with given id doesn't exist");
        var mappedEmployee = _mapper.Map<Employee>(newEmployee);
        _organizationRepository.Employees.Remove(employee);
        _organizationRepository.Employees.Add(mappedEmployee);
        return Ok(newEmployee);
    }

    [HttpDelete("{id}")]
    public ActionResult<EmployeeDTO> Delete(uint id)
    {
        var employee = _organizationRepository.Employees.FirstOrDefault(employee => employee.Id == id);
        if (employee == null) return NotFound();
        _organizationRepository.Employees.Remove(employee);
        return Ok();
    }
}
