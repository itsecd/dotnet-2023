using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
/// Controller for titles
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TitleController : ControllerBase
{
    private readonly ILogger<TitleController> _logger;
    private readonly IDbContextFactory<RecruitmentAgencyContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public TitleController(ILogger<TitleController> logger, IDbContextFactory<RecruitmentAgencyContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all titles
    /// </summary>
    /// <returns>Returns a list of all titles</returns>
    [HttpGet]
    public async Task<IEnumerable<TitleGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get titles");
        var titles = _mapper.Map<IEnumerable<TitleGetDto>>(await ctx.Titles.ToListAsync());
        return titles;
    }
    /// <summary>
    ///  Get method that returns a title with a specific id
    /// </summary>
    /// <param name="id">Title id</param>
    /// <returns>Title with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TitleGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get title with id {id}");
        var title = ctx.Titles.FirstOrDefault(title => title.Id == id);
        if (title == null)
        {
            _logger.LogInformation("Not found title with id equals to: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<TitleGetDto>(title));
    }
    /// <summary>
    /// Post method that adding a new title 
    /// </summary>
    /// <param name="title">Title data</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TitlePostDto title)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post title");
        await ctx.Titles.AddAsync(_mapper.Map<Title>(title));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put method which allows change the data of a title with a specific id
    /// </summary>
    /// <param name="id">Title id</param>
    /// <param name="titleToPut">Title data</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TitlePostDto titleToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put title with id {id}", id);
        var title = ctx.Titles.FirstOrDefault(title => title.Id == id);
        if (title == null)
        {
            _logger.LogInformation("Not found title with id {id}", id);
            return NotFound();
        }
        ctx.Update(_mapper.Map(titleToPut, title));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a title with a specific id
    /// </summary>
    /// <param name="id">Title id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Delete title with id ({id})", id);
        var title = ctx.Titles.FirstOrDefault(title => title.Id == id);
        if (title == null)
        {
            _logger.LogInformation("Not found title with id ({id})", id);
            return NotFound();
        }
        ctx.Titles.Remove(title);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
