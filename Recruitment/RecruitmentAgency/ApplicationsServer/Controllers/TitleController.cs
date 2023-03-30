using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.DTO;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;

/// <summary>
/// Controller for titles
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TitlesController : ControllerBase
{
    private readonly ILogger<TitlesController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public TitlesController(ILogger<TitlesController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all titles
    /// </summary>
    /// <returns>Returns a list of all titles</returns>
    [HttpGet]
    public IEnumerable<TitleGetDTO> Get()
    {
        _logger.LogInformation("Get titles");
        return _companiesRepository.Titles.Select(title=>_mapper.Map<TitleGetDTO>(title));
    }
    /// <summary>
    ///  Get method that returns a title with a specific id
    /// </summary>
    /// <param name="id">Title id</param>
    /// <returns>Title with required id</returns>
    [HttpGet("{id}")]
    public ActionResult<TitleGetDTO> Get(int id)
    {
        _logger.LogInformation($"Get title with id {id}");
        var title = _companiesRepository.Titles.FirstOrDefault(title => title.Id == id);
        if (title == null) 
        {
            _logger.LogInformation("Not found title with id equals to: {id}", id);
            return NotFound(); 
        }
        return Ok(_mapper.Map<TitleGetDTO>(title));
    }
    /// <summary>
    /// Post method that adding a new title 
    /// </summary>
    /// <param name="title"></param>
    [HttpPost]
    public void Post([FromBody] TitleGetDTO title)
    {
        _companiesRepository.Titles.Add(_mapper.Map<Title>(title));
    }

    /// <summary>
    /// Put method which allows change the data of a title with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="titleToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TitleGetDTO titleToPut)
    {
        _logger.LogInformation($" Attempting to change a title with an id equal to =  {id}");
        var title = _companiesRepository.Titles.FirstOrDefault(title => title.Id == id);
        if (title == null) return NotFound();
        _mapper.Map<TitleGetDTO, Title>(titleToPut, title);

        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a title with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($" Attempting to delete a title with an id equal to =  {id}");
        var title = _companiesRepository.Titles.FirstOrDefault(title => title.Id == id);
        if (title == null) return NotFound();
        _companiesRepository.Titles.Remove(title);
        return Ok();
    }
}
