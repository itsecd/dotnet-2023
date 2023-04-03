using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.Dto;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VoucherTypeController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public VoucherTypeController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<VoucherTypeDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<VoucherTypeDto>>(_organizationRepository.VoucherTypes); // использовать Take() и Skip()
    }
    [HttpGet("{id}")]
    public ActionResult<VoucherTypeDto> Get(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        var mappedVoucherType = _mapper.Map<VoucherTypeDto>(voucherType);
        return Ok(mappedVoucherType);
    }
    [HttpPost]
    public ActionResult<VoucherTypeDto> Post([FromBody] VoucherTypeDto voucherType)
    {
        var mappedVoucherType = _mapper.Map<VoucherType>(voucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
        return Ok(voucherType);
    }


    [HttpPut("{id}")]
    public ActionResult<VoucherTypeDto> Put(int id, [FromBody] VoucherTypeDto newVoucherType)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        var mappedVoucherType = _mapper.Map<VoucherType>(newVoucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
        return Ok(newVoucherType);
    }

    [HttpDelete("{id}")]
    public ActionResult<VoucherTypeDto> Delete(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        return Ok();
    }
}
