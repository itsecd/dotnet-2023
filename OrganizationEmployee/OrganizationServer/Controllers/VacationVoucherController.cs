using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

namespace OrganizationServer.Controllers;
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
    public IEnumerable<VacationVoucher> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _organizationRepository.VacationVouchers;
    }

    [HttpGet("{id}")]
    public ActionResult<VacationVoucher> Get(int id)
    {
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(vacationVoucher => vacationVoucher.Id == id);
        if (vacationVoucher == null) return NotFound();
        return Ok(vacationVoucher);
    }

    [HttpPost]
    public ActionResult<VacationVoucher> Post([FromBody] VacationVoucherDTO vacationVoucher)
    {
        var mappedVacationVoucher = _mapper.Map<VacationVoucher>(vacationVoucher);
        var voucherType =
        _organizationRepository.VoucherTypes.FirstOrDefault
                            (type => type.Name == mappedVacationVoucher?.VoucherType?.Name);
        if (voucherType == null) return NotFound("Тип путевки не найден");
        _organizationRepository.VacationVouchers.Add(mappedVacationVoucher);
        voucherType.VacationVouchers.Add(mappedVacationVoucher);
        return Ok(mappedVacationVoucher);
    }


    [HttpPut("{id}")]
    public ActionResult<VacationVoucher> Put(int id, [FromBody] VacationVoucherDTO newVacationVoucher)
    {
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(voucher => voucher.Id == id);
        if (vacationVoucher == null) return NotFound();
        _organizationRepository.VacationVouchers.Remove(vacationVoucher);
        var mappedVacationVoucher = _mapper.Map<VacationVoucher>(newVacationVoucher);
        var voucherType = 
            _organizationRepository.VoucherTypes.FirstOrDefault
                                    (type => type.Name == mappedVacationVoucher?.VoucherType?.Name);
        if (voucherType == null) return NotFound("Тип путевки не найден");
        _organizationRepository.VacationVouchers.Add(mappedVacationVoucher);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<VacationVoucher> Delete(int id)
    {
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(voucher => voucher.Id == id);
        if (vacationVoucher == null) return NotFound();
        _organizationRepository.VacationVouchers.Remove(vacationVoucher);
        return Ok();
    }
}
