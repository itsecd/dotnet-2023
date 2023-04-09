using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for VacationVoucher class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VacationVoucherController : Controller
{
    private readonly ILogger<VacationVoucherController> _logger;
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the VacationVoucherController
    /// </summary>
    public VacationVoucherController(OrganizationRepository organizationRepository, IMapper mapper,
        ILogger<VacationVoucherController> logger)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the vacation vouchers in the organization
    /// </summary>
    /// <returns>All the vacation vouchers in the organization</returns>
    [HttpGet]
    public IEnumerable<GetVacationVoucherDto> Get()
    {
        _logger.LogInformation("Get vacation vouchers");
        return _mapper.Map<IEnumerable<GetVacationVoucherDto>>(_organizationRepository.VacationVouchers);
    }
    /// <summary>
    /// The method returns an VacationVoucher by ID
    /// </summary>
    /// <param name="id">VacationVoucher ID</param>
    /// <returns>VacationVoucher with the given ID or 404 code if VacationVoucher is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<GetVacationVoucherDto> Get(int id)
    {
        _logger.LogInformation("Get vacation voucher with id {id}", id);
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(vacationVoucher => vacationVoucher.Id == id);
        if (vacationVoucher == null)
        {
            _logger.LogInformation("The vacation voucher with ID {id} is not found", id);
            return NotFound();
        }
        var mappedVacationVoucher = _mapper.Map<GetVacationVoucherDto>(vacationVoucher);
        return Ok(mappedVacationVoucher);
    }
    /// <summary>
    /// The method adds a new VacationVoucher into organization
    /// </summary>
    /// <param name="vacationVoucher">A new VacationVoucher that needs to be added</param>
    /// <returns>Code 200 with an added VacationVoucher if success
    /// Code 404 if a voucher type doesn't exist</returns>
    [HttpPost]
    public ActionResult<PostVacationVoucherDto> Post([FromBody] PostVacationVoucherDto vacationVoucher)
    {
        _logger.LogInformation("POST vacation voucher method");
        var mappedVacationVoucher = _mapper.Map<VacationVoucher>(vacationVoucher);
        var voucherType =
        _organizationRepository.VoucherTypes.FirstOrDefault
                            (type => type.Id == mappedVacationVoucher.VoucherTypeId);
        if (voucherType == null)
        {
            _logger.LogInformation("An voucher type with id {id} doesn't exist",
                mappedVacationVoucher.VoucherTypeId);
            return NotFound("A voucher type with given id doesn't exist");
        }
        _organizationRepository.VacationVouchers.Add(mappedVacationVoucher);
        voucherType.VacationVouchers.Add(mappedVacationVoucher);
        return Ok(vacationVoucher);
    }
    /// <summary>
    /// The method updates an VacationVoucher information by ID
    /// </summary>
    /// <param name="id">An ID of the VacationVoucher</param>
    /// <param name="newVacationVoucher">New information of the VacationVoucher</param>
    /// <returns>Code 200 and the updated VacationVoucher class if success; 
    /// 404 code if an VacationVoucher is not found or VoucherType is not found;</returns>
    [HttpPut("{id}")]
    public ActionResult<PostVacationVoucherDto> Put(int id, [FromBody] PostVacationVoucherDto newVacationVoucher)
    {
        _logger.LogInformation("PUT vacation voucher method");
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(voucher => voucher.Id == id);
        if (vacationVoucher == null)
        {
            _logger.LogInformation("An vacation voucher with id {id} doesn't exist", id);
            return NotFound();
        }
        var mappedVacationVoucher = _mapper.Map<VacationVoucher>(newVacationVoucher);
        var voucherType =
       _organizationRepository.VoucherTypes.FirstOrDefault
                           (type => type.Id == newVacationVoucher.VoucherTypeId);
        if (voucherType == null)
        {
            _logger.LogInformation("An voucher type with id {id} doesn't exist",
                mappedVacationVoucher.VoucherTypeId);
            return NotFound("A voucher type with given id doesn't exist");
        }

        _organizationRepository.VacationVouchers.Remove(vacationVoucher);
        _organizationRepository.VacationVouchers.Add(mappedVacationVoucher);
        return Ok(newVacationVoucher);
    }
    /// <summary>
    /// The method deletes an VacationVoucher by ID
    /// </summary>
    /// <param name="id">An ID of the VacationVoucher</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<PostVacationVoucherDto> Delete(int id)
    {
        _logger.LogInformation("PUT vacation voucher method");
        var vacationVoucher = _organizationRepository.VacationVouchers.FirstOrDefault(voucher => voucher.Id == id);
        if (vacationVoucher == null)
        {
            _logger.LogInformation("An vacation voucher with id {id} doesn't exist", id);
            return NotFound();
        }
        _organizationRepository.VacationVouchers.Remove(vacationVoucher);
        return Ok();
    }
}
