using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

namespace OrganizationServer.Controllers;
public class StatisticsController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public StatisticsController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }


    [HttpGet("department_id_{departmentId}")]
    public ActionResult<IEnumerable<EmployeeDTO>> Get(int departmentId)
    {
        var firstQuery = (from employee in _organizationRepository.EmployeesWithDepartmentEmployeeFilled
                          from departmentEmployeeItem in employee.DepartmentEmployees
                          where departmentEmployeeItem.Department?.Id == departmentId
                          select _mapper.Map<EmployeeDTO>(employee)).ToList();
        if (firstQuery.Count() == 0) return NotFound("Employees with a given department id don't exist");
        return Ok(firstQuery);
    }

    [HttpGet("employee_with_few_departments")]
    public ActionResult<IEnumerable<object>> Get()
    {
        var secondQuery = (from employee in _organizationRepository.EmployeesWithDepartmentEmployeeFilled
                           orderby employee.LastName, employee.FirstName, employee.PatronymicName
                           from departmentEmployeeItem in employee.DepartmentEmployees
                           group employee by new
                           {
                               employee.RegNumber,
                               employee.LastName,
                               employee.FirstName,
                               employee.PatronymicName
                           } into grp
                           where grp.Count() > 1
                           orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.PatronymicName
                           select new
                           {
                               grp.Key.RegNumber,
                               grp.Key.FirstName,
                               grp.Key.LastName,
                               grp.Key.PatronymicName,
                               CountDepart = grp.Count()
                           }).ToList();
        return secondQuery;
    }
}
