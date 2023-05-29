using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Domain;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for VoucherType class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VoucherTypeController : Controller
{
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly ILogger<VoucherTypeController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the VoucherTypeController
    /// </summary>
    public VoucherTypeController(IDbContextFactory<EmployeeDbContext> contextFactory,
        IMapper mapper, ILogger<VoucherTypeController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the voucher types in the organization
    /// </summary>
    /// <returns>All the voucher types in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetVoucherTypeDto>> Get()
    {
        _logger.LogInformation("Get vacation voucher types");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetVoucherTypeDto>>(ctx.VacationVouchersTypes);
    }
    /// <summary>
    /// The method returns an voucher type by ID
    /// </summary>
    /// <param name="id">VoucherType ID</param>
    /// <returns>VoucherType with the given ID or 404 code if VoucherType is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetVoucherTypeDto>> Get(int id)
    {
        _logger.LogInformation("Get voucher type with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var voucherType = ctx.VacationVouchersTypes.FirstOrDefault(voucherType => voucherType.Id == id);
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
    /// <returns>Code 201 with an added VoucherType</returns>
    [HttpPost]
    [ProducesResponseType(typeof(GetVoucherTypeDto), 201)]
    public async Task<ActionResult<GetVoucherTypeDto>> Post([FromBody] PostVoucherTypeDto voucherType)
    {
        _logger.LogInformation("POST voucher type method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedVoucherType = _mapper.Map<VoucherType>(voucherType);
        ctx.VacationVouchersTypes.Add(mappedVoucherType);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("POST", _mapper.Map<GetVoucherTypeDto>(mappedVoucherType));
    }
    /// <summary>
    /// The method updates an VoucherType information by ID
    /// </summary>
    /// <param name="id">An ID of the VoucherType</param>
    /// <param name="newVoucherType">New information of the VoucherType</param>
    /// <returns>Code 200 and the updated VoucherType class if success; 
    /// 404 code if an VoucherType is not found;</returns>

    [HttpPut("{id}")]
    public async Task<ActionResult<GetVoucherTypeDto>> Put(int id, [FromBody] PostVoucherTypeDto newVoucherType)
    {
        _logger.LogInformation("PUT voucher type method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var voucherType = ctx.VacationVouchersTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null)
        {
            _logger.LogInformation("An voucher type with id {id} doesn't exist", id);
            return NotFound();
        }
        ctx.VacationVouchersTypes.Update(_mapper.Map(newVoucherType, voucherType));
        await ctx.SaveChangesAsync();
        var mappedVoucherType = _mapper.Map<VoucherType>(newVoucherType);
        return Ok(_mapper.Map<GetVoucherTypeDto>(mappedVoucherType));
    }
    /// <summary>
    /// The method deletes an VoucherType by ID
    /// </summary>
    /// <param name="id">An ID of the VoucherType</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GetVoucherTypeDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE voucher type method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var voucherType = ctx.VacationVouchersTypes.FirstOrDefault(voucherType => voucherType.Id == id);
        if (voucherType == null)
        {
            _logger.LogInformation("An voucher type with id {id} doesn't exist", id);
            return NotFound();
        }
        ctx.VacationVouchersTypes.Remove(voucherType);
        try
        {
            await ctx.SaveChangesAsync();
        }
        catch (DbUpdateException exception)
        {
            _logger.LogInformation("SQL exception while deleting the voucher type, " +
                "exception message: ", exception.Message);
            return Conflict("Can not remove the voucher type because some rows " +
                "in other tables are pointing on that voucher type! " +
                "Remove them first and then try again!");
        }
        return Ok(_mapper.Map<GetVoucherTypeDto>(voucherType));
    }
}
