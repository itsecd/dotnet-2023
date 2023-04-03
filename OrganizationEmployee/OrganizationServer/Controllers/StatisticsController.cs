using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.Dto;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatisticsController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public StatisticsController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }


    [HttpGet("DepartmentId/{departmentId}")]
    public ActionResult<IEnumerable<EmployeeDto>> Get(int departmentId)
    {
        var firstQuery = (from employee in _organizationRepository.EmployeesWithDepartmentEmployeeFilled
                          from departmentEmployeeItem in employee.DepartmentEmployees
                          where departmentEmployeeItem.Department?.Id == departmentId
                          select _mapper.Map<EmployeeDto>(employee)).ToList();
        if (firstQuery.Count() == 0) return NotFound("Employees with a given department id don't exist");
        return Ok(firstQuery);
    }

    [HttpGet("EmployeesWithFewDepartments")]
    public ActionResult<IEnumerable<EmployeeWithFewDepartmentsDto>> GetEmployeesWithFewDepartments()
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
                           select new EmployeeWithFewDepartmentsDto()
                           {
                               RegNumber = grp.Key.RegNumber,
                               FirstName = grp.Key.FirstName,
                               LastName = grp.Key.LastName,
                               PatronymicName = grp.Key.PatronymicName,
                               CountDepart = grp.Count()
                           }).ToList();
        return secondQuery;
    }

    [HttpGet("ArchiveOfDismissals")]
    public ActionResult<IEnumerable<ArchiveOfDismissalsDto>> GetArchiveOfDismissals()
    {
        var thirdQuery = (from employeeOccupationItem in _organizationRepository.EmployeeOccupations
                          where employeeOccupationItem?.DismissalDate != null
                          from department in employeeOccupationItem?.Employee?.DepartmentEmployees
                          select
                          new ArchiveOfDismissalsDto()
                          {
                              RegNumber = employeeOccupationItem.Employee?.RegNumber,
                              FirstName = employeeOccupationItem.Employee?.FirstName,
                              LastName = employeeOccupationItem.Employee?.LastName,
                              PatronymicName = employeeOccupationItem.Employee?.PatronymicName,
                              BirthDate = employeeOccupationItem.Employee?.BirthDate,
                              WorkshopName = employeeOccupationItem.Employee?.Workshop?.Name,
                              DepartmentName = department.Department?.Name,
                              OccupationName = employeeOccupationItem?.Occupation?.Name
                          }
                      ).ToList();
        return thirdQuery;
    }
    [HttpGet("AvgAgeInDepartments")]
    public ActionResult<IEnumerable<AverageAgeInDepartmentDto>> GetAvgAgeInDepartments()
    {
        var employees = _organizationRepository.EmployeesWithDepartmentEmployeeFilled;
        var fourthQuery =
            (from tuple in
                 (from employee in employees
                  from departmentEmployeeItem in employee.DepartmentEmployees
                  where departmentEmployeeItem.Department != null
                  select new
                  {
                      EmployeeAge = ((DateTime.Now -
                                      employee.BirthDate).TotalDays / 365.2422),
                      DepartmentId = departmentEmployeeItem.Department?.Id,
                      DepartmentName = departmentEmployeeItem.Department?.Name,
                  }
                  )
             group tuple by new
             {
                 tuple.DepartmentId,
                 tuple.DepartmentName,
             } into grp
             select new AverageAgeInDepartmentDto()
             {
                 AverageAge = grp.Average(employee => employee.EmployeeAge),
                 DepartmentName = grp.Key.DepartmentName
             }
             ).ToList();
        return fourthQuery;
    }
    [HttpGet("EmployeeLastYearVoucher")]
    public ActionResult<IEnumerable<EmployeeLastYearVoucherDto>> GetEmployeeLastYearVoucher()
    {
        var fifthQuery = (from employeeVoucherItem in _organizationRepository.EmployeeVacationVouchers
                          where (new DateTime(2023, 3, 10) -
                                 employeeVoucherItem.VacationVoucher?.IssueDate)?.TotalDays < 365
                          select new EmployeeLastYearVoucherDto()
                          {
                              RegNumber = employeeVoucherItem.Employee?.RegNumber,
                              FirstName = employeeVoucherItem.Employee?.FirstName,
                              LastName = employeeVoucherItem.Employee?.LastName,
                              VoucherTypeName = employeeVoucherItem.VacationVoucher?.VoucherType?.Name
                          }
                  ).ToList();
        return fifthQuery;
    }
    [HttpGet("EmployeeWithLongestWorkExperience")]
    public ActionResult<IEnumerable<EmployeeWorkExperienceDto>> GetEmployeeWithLongestWorkExperience()
    {
        var subqueryReplaceNull = (from employeeOccupationItem in _organizationRepository.EmployeeOccupations
                                   select new
                                   {
                                       employeeOccupationItem.Employee?.RegNumber,
                                       employeeOccupationItem.HireDate,
                                       DismissalDate = employeeOccupationItem.DismissalDate ?? DateTime.Now,
                                       employeeOccupationItem.Employee?.FirstName,
                                       employeeOccupationItem.Employee?.LastName
                                   }
                               ).ToList();
        var sixthQuery = (from subqueryElem in subqueryReplaceNull
                          group subqueryElem by new
                          {
                              subqueryElem.RegNumber,
                              subqueryElem.FirstName,
                              subqueryElem.LastName
                          } into grp
                          orderby grp.Sum(subqueryElem =>
                                          (subqueryElem.DismissalDate -
                                           subqueryElem.HireDate).TotalDays / 365.2422) descending
                          select new EmployeeWorkExperienceDto()
                          {
                              RegNumber = grp.Key.RegNumber,
                              FirstName = grp.Key.FirstName,
                              LastName = grp.Key.LastName,
                              WorkExperience = grp.Sum(subqueryElem =>
                              (subqueryElem.DismissalDate -
                               subqueryElem.HireDate).TotalDays / 365.2422)
                          }
                          ).Take(5).ToList();
        return sixthQuery;
    }
}
