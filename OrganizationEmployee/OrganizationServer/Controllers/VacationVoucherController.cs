using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;
using OrganizationEmployee.EmployeeDomain;

namespace OrganizationEmployee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VacationVoucherController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public VacationVoucherController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<VacationVoucherDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<VacationVoucherDto>>(_organizationRepository.VacationVouchers);
    }

    [HttpGet("{id}")]
    public ActionResult<VacationVoucherDto> Get(int id)
    {
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(vacationVoucher => vacationVoucher.Id == id);
        if (vacationVoucher == null) return NotFound();
        var mappedVacationVoucher = _mapper.Map<VacationVoucherDto>(vacationVoucher);
        return Ok(mappedVacationVoucher);
    }

    [HttpPost]
    public ActionResult<VacationVoucherDto> Post([FromBody] VacationVoucherDto vacationVoucher)
    {
        var mappedVacationVoucher = _mapper.Map<VacationVoucher>(vacationVoucher);
        var voucherType =
        _organizationRepository.VoucherTypes.FirstOrDefault
                            (type => type.Id == mappedVacationVoucher.VoucherTypeId);
        if (voucherType == null) return NotFound("A voucher type with given id doesn't exist");
        _organizationRepository.VacationVouchers.Add(mappedVacationVoucher);
        voucherType.VacationVouchers.Add(mappedVacationVoucher);
        return Ok(vacationVoucher);
    }


    [HttpPut("{id}")]
    public ActionResult<VacationVoucherDto> Put(int id, [FromBody] VacationVoucherDto newVacationVoucher)
    {
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(voucher => voucher.Id == id);
        if (vacationVoucher == null) return NotFound();
        var mappedVacationVoucher = _mapper.Map<VacationVoucher>(newVacationVoucher);
        var voucherType =
       _organizationRepository.VoucherTypes.FirstOrDefault
                           (type => type.Id == newVacationVoucher.VoucherTypeId);
        if (voucherType == null) return NotFound("A voucher type with given id doesn't exist");

        _organizationRepository.VacationVouchers.Remove(vacationVoucher);
        _organizationRepository.VacationVouchers.Add(mappedVacationVoucher);
        return Ok(newVacationVoucher);
    }

    [HttpDelete("{id}")]
    public ActionResult<VacationVoucherDto> Delete(int id)
    {
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(voucher => voucher.Id == id);
        if (vacationVoucher == null) return NotFound();
        _organizationRepository.VacationVouchers.Remove(vacationVoucher);
        return Ok();
    }
}
