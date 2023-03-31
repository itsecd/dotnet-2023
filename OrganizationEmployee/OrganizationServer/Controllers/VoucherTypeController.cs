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
    public IEnumerable<VoucherTypeDTO> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<VoucherTypeDTO>>(_organizationRepository.VoucherTypes); // использовать Take() и Skip()
    }
    [HttpGet("{id}")]
    public ActionResult<VoucherTypeDTO> Get(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        var mappedVoucherType = _mapper.Map<VoucherTypeDTO>(voucherType);
        return Ok(mappedVoucherType);
    }
    [HttpPost]
    public ActionResult<VoucherTypeDTO> Post([FromBody] VoucherTypeDTO voucherType)
    {
        var mappedVoucherType = _mapper.Map<VoucherType>(voucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
        return Ok(voucherType);
    }


    [HttpPut("{id}")]
    public ActionResult<VoucherTypeDTO> Put(int id, [FromBody] VoucherTypeDTO newVoucherType)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        var mappedVoucherType = _mapper.Map<VoucherType>(newVoucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
        return Ok(newVoucherType);
    }

    [HttpDelete("{id}")]
    public ActionResult<VoucherTypeDTO> Delete(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        return Ok();
    }
}
