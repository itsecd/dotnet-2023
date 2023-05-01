using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OrganizationServer.Dto;
using OrganizationServer.Repository;

namespace OrganizationServer.Controllers;
/// <summary>
/// Controller for statistical data of the organization
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class StatisticsController : Controller
{
    private readonly ILogger<StatisticsController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the StatisticsController
    /// </summary>
    public StatisticsController(IDbContextFactory<EmployeeDbContext> contextFactory, 
        IMapper mapper, ILogger<StatisticsController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method outputs all employees of the given department
    /// </summary>
    /// <param name="departmentId">An ID of the department</param>
    /// <returns>Code 200 with statistical data in form of IEnumerable of PostEmployeeDto
    /// Code 404 if a department with given ID doesn't exist</returns>
    [HttpGet("DepartmentId/{departmentId}")]
    public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> Get(int departmentId)
    {
        _logger.LogInformation("Get all employees of the given department");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeesInDepartment = (from employee in ctx.Employees
                                     from departmentEmployeeItem in employee.DepartmentEmployees
                                     where departmentEmployeeItem.Department.Id == departmentId
                                     select _mapper.Map<GetEmployeeDto>(employee)).ToList();
        if (employeesInDepartment.Count() == 0)
        {
            _logger.LogInformation("Employees with a given department id {id} don't exist", departmentId);
            return NotFound("Employees with a given department id don't exist");
        }
        return Ok(employeesInDepartment);
    }
    /// <summary>
    /// The method outputs all employees working in more than 1 department. 
    /// The result is sorted by last name, first name, patronymic name.
    /// </summary>
    /// <returns>Code 200 with statistical data in form of IEnumerable of EmployeeWithFewDepartmentsDto</returns>
    [HttpGet("EmployeesWithFewDepartments")]
    public async Task<ActionResult<IEnumerable<EmployeeWithFewDepartmentsDto>>> GetEmployeesWithFewDepartments()
    {
        _logger.LogInformation("Get all employees working in more than 1 department");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeesWithFewDepartments =
            (from employee in ctx.Employees
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
        return Ok(employeesWithFewDepartments);
    }
    /// <summary>
    /// The method outputs the archive of dismissals, including registration number, first name, last name, patronymic name,
    /// date of birth, workshop, department, occupation of the employee.
    /// </summary>
    /// <returns>Code 200 with statistical data in form of IEnumerable of ArchiveOfDismissalsDto</returns>
    [HttpGet("ArchiveOfDismissals")]
    public async Task<ActionResult<IEnumerable<ArchiveOfDismissalsDto>>> GetArchiveOfDismissals()
    {
        _logger.LogInformation("Get archive of dismissals");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var archiveOfDismissals = (from employeeOccupationItem in ctx.EmployeeOccupations
                                   where employeeOccupationItem.DismissalDate != null
                                   from department in employeeOccupationItem.Employee.DepartmentEmployees
                                   select
                                   new ArchiveOfDismissalsDto()
                                   {
                                       RegNumber = employeeOccupationItem.Employee.RegNumber,
                                       FirstName = employeeOccupationItem.Employee.FirstName,
                                       LastName = employeeOccupationItem.Employee.LastName,
                                       PatronymicName = employeeOccupationItem.Employee.PatronymicName,
                                       BirthDate = employeeOccupationItem.Employee.BirthDate,
                                       WorkshopName = employeeOccupationItem.Employee.Workshop.Name,
                                       DepartmentName = department.Department.Name,
                                       OccupationName = employeeOccupationItem.Occupation.Name
                                   }
                      ).ToList();
        return Ok(archiveOfDismissals);
    }
    /// <summary>
    /// The method outputs an average age of employees for each department
    /// </summary>
    /// <returns>Code 200 with statistical data in form of IEnumerable of AverageAgeInDepartmentDto</returns>
    [HttpGet("AvgAgeInDepartments")]
    public async Task<ActionResult<IEnumerable<AverageAgeInDepartmentDto>>> GetAvgAgeInDepartments()
    {
        _logger.LogInformation("Get average age of employees for each department");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employees = ctx.Employees.Include(employee => employee.DepartmentEmployees)
            .ThenInclude(departmentEmployee => departmentEmployee.Department).ToList();
        var avgAgeInDepartments =
            (from tuple in
                 (from employee in employees
                  from departmentEmployeeItem in employee.DepartmentEmployees
                  where departmentEmployeeItem.Department != null
                  select new
                  {
                      EmployeeAge = ((DateTime.Now -
                                      employee.BirthDate).TotalDays / 365.2422),
                      DepartmentId = departmentEmployeeItem.Department.Id,
                      DepartmentName = departmentEmployeeItem.Department.Name,
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
        return Ok(avgAgeInDepartments);
    }
    /// <summary>
    /// The method outputs the info about employees, who received a vacation voucher in past year.
    /// </summary>
    /// <returns>Code 200 with statistical data in form of IEnumerable of EmployeeLastYearVoucherDto</returns>
    [HttpGet("EmployeeLastYearVoucher")]
    public async Task<ActionResult<IEnumerable<EmployeeLastYearVoucherDto>>> GetEmployeeLastYearVoucher()
    {
        _logger.LogInformation("Get the info about employees, who received a vacation voucher in past year");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeeVacationVouchers = ctx.EmployeeVacationVouchers
            .Include(emplVacationVoucher => emplVacationVoucher.VacationVoucher)
            .Include(emplVacationVoucher => emplVacationVoucher.Employee)
            .ToList();
        var employeeLastYearVoucher =
            (from employeeVoucherItem in employeeVacationVouchers
             where (new DateTime(2023, 3, 10) - employeeVoucherItem!.VacationVoucher!.IssueDate).TotalDays < 365
             select new EmployeeLastYearVoucherDto()
             {
                 RegNumber = employeeVoucherItem?.Employee?.RegNumber,
                 FirstName = employeeVoucherItem?.Employee?.FirstName,
                 LastName = employeeVoucherItem?.Employee?.LastName,
                 VoucherTypeName = employeeVoucherItem?.VacationVoucher?.VoucherType?.Name
             }
             ).ToList();
        return Ok(employeeLastYearVoucher);
    }
    /// <summary>
    /// The method outputs the top-5 employees who have the longest working experience at the company.
    /// </summary>
    /// <returns>Code 200 with statistical data in form of IEnumerable of EmployeeWorkExperienceDto</returns>
    [HttpGet("EmployeeWithLongestWorkExperience")]
    public async Task<ActionResult<IEnumerable<EmployeeWorkExperienceDto>>> GetEmployeeWithLongestWorkExperience()
    {
        _logger.LogInformation("Get the top-5 employees who have the longest working experience at the company");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var subqueryReplaceNull = (from employeeOccupationItem in ctx.EmployeeOccupations
                                   select new
                                   {
                                       employeeOccupationItem.Employee.RegNumber,
                                       employeeOccupationItem.HireDate,
                                       DismissalDate = employeeOccupationItem.DismissalDate ?? DateTime.Now,
                                       employeeOccupationItem.Employee.FirstName,
                                       employeeOccupationItem.Employee.LastName
                                   }
                               ).ToList();
        var employeeWorkExperience =
            (from subqueryElem in subqueryReplaceNull
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
        return Ok(employeeWorkExperience);
    }
}
