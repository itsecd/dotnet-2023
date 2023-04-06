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
    private readonly ILogger<VoucherTypeController> _logger;
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the VoucherTypeController
    /// </summary>
    public VoucherTypeController(OrganizationRepository organizationRepository, IMapper mapper, 
        ILogger<VoucherTypeController> logger)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the voucher types in the organization
    /// </summary>
    /// <returns>All the voucher types in the organization</returns>
    [HttpGet]
    public IEnumerable<GetVoucherTypeDto> Get()
    {
        _logger.LogInformation("Get vacation voucher types");
        return _mapper.Map<IEnumerable<GetVoucherTypeDto>>(_organizationRepository.VoucherTypes);
    }
    /// <summary>
    /// The method returns an voucher type by ID
    /// </summary>
    /// <param name="id">VoucherType ID</param>
    /// <returns>VoucherType with the given ID or 404 code if VoucherType is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<GetVoucherTypeDto> Get(int id)
    {
        _logger.LogInformation("Get voucher type with id {id}", id);
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null)
        {
            _logger.LogInformation("The voucher type with ID {id} is not found", id);
            return NotFound();
        }
        var mappedVoucherType = _mapper.Map<GetVoucherTypeDto>(voucherType);
        return Ok(mappedVoucherType);
    }
    /// <summary>
    /// The method adds a new VoucherType into organization
    /// </summary>
    /// <param name="voucherType">A new VoucherType that needs to be added</param>
    /// <returns>Code 200 with an added VoucherType</returns>
    [HttpPost]
    public ActionResult<PostVoucherTypeDto> Post([FromBody] PostVoucherTypeDto voucherType)
    {
        _logger.LogInformation("POST voucher type method");
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
    public ActionResult<PostVoucherTypeDto> Put(int id, [FromBody] PostVoucherTypeDto newVoucherType)
    {
        _logger.LogInformation("PUT voucher type method");
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null)
        {
            _logger.LogInformation("An voucher type with id {id} doesn't exist", id);
            return NotFound();
        }
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
    public ActionResult<PostVoucherTypeDto> Delete(int id)
    {
        _logger.LogInformation("DELETE voucher type method");
        var voucherType = _organizationRepository.VoucherTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null)
        {
            _logger.LogInformation("An voucher type with id {id} doesn't exist", id);
            return NotFound();
        }
        _organizationRepository.VoucherTypes.Remove(voucherType);
        return Ok();
    }
}
