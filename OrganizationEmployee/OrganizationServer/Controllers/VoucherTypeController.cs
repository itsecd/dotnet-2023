using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for VoucherType class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VoucherTypeController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the VoucherTypeController
    /// </summary>
    public VoucherTypeController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// The method returns all the voucher types in the organization
    /// </summary>
    /// <returns>All the voucher types in the organization</returns>
    [HttpGet]
    public IEnumerable<VoucherTypeDto> Get()
    {
        return _mapper.Map<IEnumerable<VoucherTypeDto>>(_organizationRepository.VoucherTypes);
    }
    /// <summary>
    /// The method returns an voucher type by ID
    /// </summary>
    /// <param name="id">VoucherType ID</param>
    /// <returns>VoucherType with the given ID or 404 code if VoucherType is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<VoucherTypeDto> Get(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        var mappedVoucherType = _mapper.Map<VoucherTypeDto>(voucherType);
        return Ok(mappedVoucherType);
    }
    /// <summary>
    /// The method adds a new VoucherType into organization
    /// </summary>
    /// <param name="voucherType">A new VoucherType that needs to be added</param>
    /// <returns>Code 200 with an added VoucherType</returns>
    [HttpPost]
    public ActionResult<VoucherTypeDto> Post([FromBody] VoucherTypeDto voucherType)
    {
        var mappedVoucherType = _mapper.Map<VoucherType>(voucherType);
        _organizationRepository.VoucherTypes.Add(mappedVoucherType);
        return Ok(voucherType);
    }
    /// <summary>
    /// The method updates an VoucherType information by ID
    /// </summary>
    /// <param name="id">An ID of the VoucherType</param>
    /// <param name="newVoucherType">New information of the VoucherType</param>
    /// <returns>Code 200 and the updated VoucherType class if success; 
    /// 404 code if an VoucherType is not found;</returns>

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
    /// <summary>
    /// The method deletes an VoucherType by ID
    /// </summary>
    /// <param name="id">An ID of the VoucherType</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<VoucherTypeDto> Delete(int id)
    {
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null) return NotFound();
        _organizationRepository.VoucherTypes.Remove(voucherType);
        return Ok();
    }
}
