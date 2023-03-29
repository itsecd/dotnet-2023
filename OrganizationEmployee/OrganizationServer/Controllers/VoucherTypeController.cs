using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

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
    public IEnumerable<VoucherType> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _organizationRepository.VoucherTypes; // использовать Take() и Skip()
    }
    [HttpGet("{id}")]
    public ActionResult<VoucherType> Get(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        return Ok(voucherType);
    }
    [HttpPost]
    public void Post([FromBody] VoucherTypeDTO voucherType)
    {
        var mappedVoucherType = _mapper.Map<VoucherType>(voucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
    }


    [HttpPut("{id}")]
    public ActionResult<VoucherType> Put(int id, [FromBody] VoucherTypeDTO newVoucherType)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        var mappedVoucherType = _mapper.Map<VoucherType>(newVoucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<VoucherType> Delete(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        return Ok();
    }
}
