using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.Dto;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeVacationVoucherController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public EmployeeVacationVoucherController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<EmployeeVacationVoucherDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<EmployeeVacationVoucherDto>>(_organizationRepository.EmployeeVacationVouchers);
    }

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
