using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResultController : ControllerBase
{
    private readonly ILogger<ResultController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public ResultController(ILogger<ResultController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Results
    /// </summary>
    /// <returns> IEnumerable type collection Result </returns>
    [HttpGet]
    public async Task<IEnumerable<ResultGetDto>> Get()
    {
        _logger.LogInformation("Get all Results");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var results = await ctx.Results.ToArrayAsync();
        return _mapper.Map<IEnumerable<ResultGetDto>>(results);
    }

    /// <summary>
    /// Get Result by id
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <returns>Ok with EntrantGetDto or NotFound</returns>
    [HttpGet("{idResult}")]
    public async Task<ActionResult<ResultGetDto>> Get(int idResult)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await ctx.Results.FirstOrDefaultAsync(result => result.IdResult == idResult);
        if (result == null)
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this idResult {idResult}");
        }
        else
        {
            _logger.LogInformation("Get Result by id {idResult}", idResult);
            return Ok(_mapper.Map<ResultGetDto>(result));
        }
    }

    /// <summary>
    /// Create new Result
    /// </summary>
    /// <param name="result">new result</param>
    [HttpPost]
    public async Task Post([FromBody] ResultPostDto result)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new Result");
        await ctx.Results.AddAsync(_mapper.Map<Result>(result));
        await ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Update information about Result
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <param name="resultToPut">Result that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idResult}")]
    public async Task<IActionResult> Put(int idResult, [FromBody] ResultPostDto resultToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await ctx.Results.FirstOrDefaultAsync(result => result.IdResult == idResult);
        if (result == null)
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this id {idResult}");
        }
        else
        {
            _logger.LogInformation("Update Result by id {idResult}", idResult);
            _mapper.Map(resultToPut, result);
            ctx.Results.Update(_mapper.Map<Result>(result));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Result
    /// </summary>
    /// <param name="idResult">id Result for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idResult}")]
    public async Task<IActionResult> Delete(int idResult)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await ctx.Results.Include(result => result.EntrantResults)
                                      .FirstOrDefaultAsync(result => result.IdResult == idResult);
        if (result == null)
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this id {idResult}");
        }
        else
        {
            _logger.LogInformation("Delete Result by id {idResult}", idResult);
            ctx.Results.Remove(result);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}