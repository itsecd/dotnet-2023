using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

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
    public IEnumerable<EmployeeVacationVoucher> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _organizationRepository.EmployeeVacationVouchers;
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeVacationVoucher> Get(int id)
    {
        var employeeVacationVoucher =
            _organizationRepository.EmployeeVacationVouchers
            .FirstOrDefault(employeeVacationVoucher => employeeVacationVoucher.Id == id);
        if (employeeVacationVoucher == null) return NotFound();
        return Ok(employeeVacationVoucher);
    }

    [HttpPost]
    public ActionResult<EmployeeVacationVoucher> Post([FromBody] EmployeeVacationVoucherDTO employeeVoucher)
    {
        var mappedEmployeeVoucher = _mapper.Map<EmployeeVacationVoucher>(employeeVoucher);
        var employee =
            _organizationRepository.Employees
            .FirstOrDefault(employee => employee.Id == mappedEmployeeVoucher.EmployeeId);
        if (employee == null) return NotFound("An employee with given id doesn't exist");
        var voucher =
            _organizationRepository.VacationVouchers
            .FirstOrDefault(voucher => voucher.Id == mappedEmployeeVoucher.VacationVoucherId);
        if (employee == null) return NotFound("A vacation voucher with given id doesn't exist");
        mappedEmployeeVoucher.VacationVoucher = voucher;
        mappedEmployeeVoucher.Employee = employee;
        _organizationRepository.EmployeeVacationVouchers.Add(mappedEmployeeVoucher);
        return Ok(mappedEmployeeVoucher);
    }


    [HttpPut("{id}")]
    public ActionResult<EmployeeVacationVoucher> Put(int id, [FromBody] EmployeeVacationVoucherDTO newEmployeeVoucher)
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
        if (employee == null) return NotFound("A vacation voucher with given id doesn't exist");
        mappedEmployeeVoucher.VacationVoucher = voucher;
        mappedEmployeeVoucher.Employee = employee;

        _organizationRepository.EmployeeVacationVouchers.Remove(employeeVoucher);
        _organizationRepository.EmployeeVacationVouchers.Add(mappedEmployeeVoucher);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<Department> Delete(int id)
    {
        var employeeVoucher =
            _organizationRepository.EmployeeVacationVouchers
            .FirstOrDefault(employeeVoucher => employeeVoucher.Id == id);
        if (employeeVoucher == null) return NotFound();
        _organizationRepository.EmployeeVacationVouchers.Remove(employeeVoucher);
        return Ok();
    }
}
