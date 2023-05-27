using AutoMapper;
using Organization.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for EmployeeVacationVoucher class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EmployeeVacationVoucherController : Controller
{
    private readonly ILogger<EmployeeVacationVoucherController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the EmployeeVacationVoucher
    /// </summary>
    public EmployeeVacationVoucherController(IDbContextFactory<EmployeeDbContext> contextFactory, IMapper mapper,
        ILogger<EmployeeVacationVoucherController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the connections between Employee and VacationVoucher
    /// </summary>
    /// <returns>All the connections between Employee and VacationVoucher in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetEmployeeVacationVoucherDto>> Get()
    {
        _logger.LogInformation("Get EmployeeVacationVouchers");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetEmployeeVacationVoucherDto>>(ctx.EmployeeVacationVouchers);
    }
    /// <summary>
    /// The method returns a EmployeeVacationVoucher by ID
    /// </summary>
    /// <param name="id">EmployeeVacationVoucher ID</param>
    /// <returns>EmployeeVacationVoucher with the given ID or 404 code if EmployeeVacationVoucher is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetEmployeeVacationVoucherDto>> Get(int id)
    {
        _logger.LogInformation("Get EmployeeVacationVoucher with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeeVacationVoucher =
            ctx.EmployeeVacationVouchers.FirstOrDefault(employeeVacationVoucher => employeeVacationVoucher.Id == id);
        if (employeeVacationVoucher == null)
        {
            _logger.LogInformation("The EmployeeVacationVoucher with ID {id} is not found", id);
            return NotFound();
        }
        var mappedEmployeeVacationVoucher = _mapper.Map<GetEmployeeVacationVoucherDto>(employeeVacationVoucher);
        return Ok(mappedEmployeeVacationVoucher);
    }
    /// <summary>
    /// The method adds a new EmployeeVacationVoucher into organization
    /// </summary>
    /// <param name="employeeVoucher">A new EmployeeVacationVoucher that needs to be added</param>
    /// <returns>Code 200 and the added EmployeeVacationVoucher is success; 404 code if department or 
    /// vacation voucher is not found </returns>
    [HttpPost]
    public async Task<ActionResult<PostEmployeeVacationVoucherDto>> Post
        ([FromBody] PostEmployeeVacationVoucherDto employeeVoucher)
    {
        _logger.LogInformation("POST EmployeeVacationVoucher method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedEmployeeVoucher = _mapper.Map<EmployeeVacationVoucher>(employeeVoucher);
        var employee =
            ctx.Employees.FirstOrDefault(employee => employee.Id == mappedEmployeeVoucher.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("An employee with id {id} doesn't exist", employeeVoucher.EmployeeId);
            return NotFound("An employee with given id doesn't exist");
        }
        var voucher =
            ctx.VacationVouchers.FirstOrDefault(voucher => voucher.Id == mappedEmployeeVoucher.VacationVoucherId);
        if (voucher == null)
        {
            _logger.LogInformation("An vacation voucher with id {id} doesn't exist",
                employeeVoucher.VacationVoucherId);
            return NotFound("A vacation voucher with given id doesn't exist");
        }
        mappedEmployeeVoucher.VacationVoucher = voucher;
        mappedEmployeeVoucher.Employee = employee;
        ctx.EmployeeVacationVouchers.Add(mappedEmployeeVoucher);
        await ctx.SaveChangesAsync();
        return Ok(employeeVoucher);
    }
    /// <summary>
    /// The method updates an EmployeeVacationVoucher information by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeVacationVoucher</param>
    /// <param name="newEmployeeVoucher">New information of the EmployeeVacationVoucher</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<PostEmployeeVacationVoucherDto>> Put
        (int id, [FromBody] PostEmployeeVacationVoucherDto newEmployeeVoucher)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("PUT EmployeeVacationVoucher method");
        var employeeVoucher =
            ctx.EmployeeVacationVouchers.FirstOrDefault(employeeVoucher => employeeVoucher.Id == id);
        if (employeeVoucher == null)
        {
            _logger.LogInformation("The EmployeeVacationVoucher with ID {id} is not found", id);
            return NotFound("The EmployeeVacationVoucher with given id is not found");
        }

        var mappedEmployeeVoucher = _mapper.Map<EmployeeVacationVoucher>(newEmployeeVoucher);
        var employee =
            ctx.Employees.FirstOrDefault(employee => employee.Id == mappedEmployeeVoucher.EmployeeId);
        if (employee == null)
        {
            _logger.LogInformation("An employee with id {id} doesn't exist", newEmployeeVoucher.EmployeeId);
            return NotFound("An employee with given id doesn't exist");
        }

        var voucher =
            ctx.VacationVouchers.FirstOrDefault(voucher => voucher.Id == mappedEmployeeVoucher.VacationVoucherId);
        if (voucher == null)
        {
            _logger.LogInformation("An vacation voucher with id {id} doesn't exist",
                employeeVoucher.VacationVoucherId);
            return NotFound("A vacation voucher with given id doesn't exist");
        }
        ctx.EmployeeVacationVouchers.Update(_mapper.Map(newEmployeeVoucher, employeeVoucher));
        await ctx.SaveChangesAsync();
        return Ok(newEmployeeVoucher);
    }
    /// <summary>
    /// The method deletes a EmployeeVacationVoucher by ID
    /// </summary>
    /// <param name="id">An ID of the EmployeeVacationVoucher</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<PostEmployeeVacationVoucherDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE EmployeeVacationVoucher method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var employeeVoucher =
            ctx.EmployeeVacationVouchers.FirstOrDefault(employeeVoucher => employeeVoucher.Id == id);
        if (employeeVoucher == null)
        {
            _logger.LogInformation("The EmployeeVacationVoucher with ID {id} is not found", id);
            return NotFound();
        }
        ctx.EmployeeVacationVouchers.Remove(employeeVoucher);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
