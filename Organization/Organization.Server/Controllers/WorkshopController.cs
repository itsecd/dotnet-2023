using AutoMapper;
using Organization.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for Workshop class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkshopController : ControllerBase
{
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly ILogger<WorkshopController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the WorkshopController
    /// </summary>
    public WorkshopController(IDbContextFactory<EmployeeDbContext> contextFactory, IMapper mapper,
        ILogger<WorkshopController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the workshops in the organization
    /// </summary>
    /// <returns>All the workshops in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetWorkshopDto>> Get()
    {
        _logger.LogInformation("Get workshops");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetWorkshopDto>>(ctx.Workshops);
    }
    /// <summary>
    /// The method returns an workshop by ID
    /// </summary>
    /// <param name="id">Workshop ID</param>
    /// <returns>Workshop with the given ID or 404 code if workshop is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetWorkshopDto>> Get(int id)
    {
        _logger.LogInformation("Get workshop with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var workshop = ctx.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null)
        {
            _logger.LogInformation("The workshop with ID {id} is not found", id);
            return NotFound();
        }
        var mappedWorkshop = _mapper.Map<GetWorkshopDto>(workshop);
        return Ok(mappedWorkshop);
    }
    /// <summary>
    /// The method adds a new workshop into organization
    /// </summary>
    /// <param name="workshop">A new workshop that needs to be added</param>
    /// <returns>Code 201 with an added workshop</returns>
    [HttpPost]
    [ProducesResponseType(typeof(GetWorkshopDto), 201)]
    public async Task<ActionResult<GetWorkshopDto>> Post([FromBody] PostWorkshopDto workshop)
    {
        _logger.LogInformation("POST workshop method");
        var mappedWorkshop = _mapper.Map<Workshop>(workshop);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Workshops.Add(mappedWorkshop);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("POST", _mapper.Map<GetWorkshopDto>(mappedWorkshop));
    }
    /// <summary>
    /// The method updates a workshop information by ID
    /// </summary>
    /// <param name="id">An ID of the workshop</param>
    /// <param name="newWorkshop">New information of the workshop</param>
    /// <returns>Code 200 and the updated workshop class if success; 
    /// 404 code if a workshop is not found;</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GetWorkshopDto>> Put(int id, [FromBody] PostWorkshopDto newWorkshop)
    {
        _logger.LogInformation("PUT workshop method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var workshop = ctx.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null)
        {
            _logger.LogInformation("An workshop with id {id} doesn't exist", id);
            return NotFound();
        }
        ctx.Workshops.Update(_mapper.Map(newWorkshop, workshop));
        await ctx.SaveChangesAsync();
        var mappedWorkshop = _mapper.Map<Workshop>(newWorkshop);
        return Ok(_mapper.Map<GetWorkshopDto>(mappedWorkshop));
    }
    /// <summary>
    /// The method deletes a workshop by ID
    /// </summary>
    /// <param name="id">An ID of the workshop</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GetWorkshopDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE workshop method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var workshop = ctx.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null)
        {
            _logger.LogInformation("An workshop with id {id} doesn't exist", id);
            return NotFound();
        }
        ctx.Workshops.Remove(workshop);
        try
        {
            await ctx.SaveChangesAsync();
        }
        catch (DbUpdateException exception)
        {
            _logger.LogInformation("SQL exception while deleting the workshop, " +
                "exception message: ", exception.Message);
            return Conflict("Can not remove the workshop because some rows " +
                "in other tables are pointing on that workshop! " +
                "Remove them first and then try again!");
        }
        return Ok(_mapper.Map<GetWorkshopDto>(workshop));
    }
}
