using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;
using OrganizationEmployee.EmployeeDomain;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for EmployeeVacationVoucher class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeVacationVoucherController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the EmployeeVacationVoucher
    /// </summary>
    public EmployeeVacationVoucherController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// The method returns all the connections between Employee and VacationVoucher
    /// </summary>
    /// <returns>All the connections between Employee and VacationVoucher in the organization</returns>
    [HttpGet]
    public IEnumerable<EmployeeVacationVoucherDto> Get()
    {
        return _mapper.Map<IEnumerable<EmployeeVacationVoucherDto>>(_organizationRepository.EmployeeVacationVouchers);
    }
    /// <summary>
    /// The method returns a EmployeeVacationVoucher by ID
    /// </summary>
    /// <param name="id">EmployeeVacationVoucher ID</param>
    /// <returns>EmployeeVacationVoucher with the given ID or 404 code if EmployeeVacationVoucher is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployeeVacationVoucherDto> Get(int id)
    {
        var employeeVacationVoucher =
            _organizationRepository.EmployeeVacationVouchers
            .FirstOrDefault(employeeVacationVoucher => employeeVacationVoucher.Id == id);
        if (employeeVacationVoucher == null) return NotFound();
        var mappedEmployeeVacationVoucher = _mapper.Map<EmployeeVacationVoucherDto>(employeeVacationVoucher);
        return Ok(mappedEmployeeVacationVoucher);
    }
    /// <summary>
    /// The method adds a new EmployeeVacationVoucher into organization
    /// </summary>
    /// <param name="employeeVoucher">A new EmployeeVacationVoucher that needs to be added</param>
    /// <returns>Code 200 and the added EmployeeVacationVoucher is success; 404 code if department or 
    /// vacation voucher is not found </returns>
    [HttpPost]
    public ActionResult<EmployeeVacationVoucherDto> Post([FromBody] EmployeeVacationVoucherDto employeeVoucher)
    {
        var mappedEmployeeVoucher = _mapper.Map<EmployeeVacationVoucher>(employeeVoucher);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeVoucher.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var voucher =
            _organizationRepository.VacationVouchers
            .FirstOrDefault(voucher => voucher.Id == mappedEmployeeVoucher.VacationVoucherId);
        if (voucher == null) return NotFound("A vacation voucher with given id doesn't exist");
        mappedEmployeeVoucher.VacationVoucher = voucher;
        mappedEmployeeVoucher.Employee = employee;
        _organizationRepository.EmployeeVacationVouchers.Add(mappedEmployeeVoucher);
        return Ok(employeeVoucher);
    }
    /// <summary>
    /// The method updates an EmployeeVacationVoucher information by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeVacationVoucher</param>
    /// <param name="newEmployeeVoucher">New information of the EmployeeVacationVoucher</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpPut("{id}")]
    public ActionResult<EmployeeVacationVoucherDto> Put(int id, [FromBody] EmployeeVacationVoucherDto newEmployeeVoucher)
    {
        var employeeVoucher = _organizationRepository
            .EmployeeVacationVouchers.FirstOrDefault(employeeVoucher => employeeVoucher.Id == id);
        if (employeeVoucher == null) return NotFound();

        var mappedEmployeeVoucher = _mapper.Map<EmployeeVacationVoucher>(newEmployeeVoucher);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeVoucher.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var voucher =
            _organizationRepository.VacationVouchers
            .FirstOrDefault(voucher => voucher.Id == mappedEmployeeVoucher.VacationVoucherId);
        if (voucher == null) return NotFound("A vacation voucher with given id doesn't exist");
        mappedEmployeeVoucher.VacationVoucher = voucher;
        mappedEmployeeVoucher.Employee = employee;

        _organizationRepository.EmployeeVacationVouchers.Remove(employeeVoucher);
        _organizationRepository.EmployeeVacationVouchers.Add(mappedEmployeeVoucher);
        return Ok(newEmployeeVoucher);
    }
    /// <summary>
    /// The method deletes a EmployeeVacationVoucher by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeVacationVoucher</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<EmployeeVacationVoucherDto> Delete(int id)
    {
        var employeeVoucher =
            _organizationRepository.EmployeeVacationVouchers
            .FirstOrDefault(employeeVoucher => employeeVoucher.Id == id);
        if (employeeVoucher == null) return NotFound();
        _organizationRepository.EmployeeVacationVouchers.Remove(employeeVoucher);
        return Ok();
    }
}
