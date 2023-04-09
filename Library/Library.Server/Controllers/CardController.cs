using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// Card controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<CardController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ILibraryRepository _librariesRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Card controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    /// <param name="mapper"></param>
    public CardController(ILogger<CardController> logger, ILibraryRepository librariesRepository, IMapper mapper)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all cards
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<CardGetDto> Get()
    {
        return _librariesRepository.Cards.Select(card => _mapper.Map<CardGetDto>(card)); ;
    }
    /// <summary>
    /// Return info about card by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<CardGetDto> Get(int id)
    {
        var card = _librariesRepository.Cards.FirstOrDefault(card => card.Id == id);
        if (card == null)
        {
            _logger.LogInformation("Not found card: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<CardGetDto>(card));
        }
    }
    /// <summary>
    /// Add a new card
    /// </summary>
    /// <param name="card"></param>
    [HttpPost]
    public void Post([FromBody] CardPostDto card)
    {
        _librariesRepository.Cards.Add(_mapper.Map<Card>(card));
        _logger.LogInformation("Added");
    }
    /// <summary>
    /// Сhange info of selected card
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cardToPut"></param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CardPostDto cardToPut)
    {
        var card = _librariesRepository.Cards.FirstOrDefault(card => card.Id == id);
        if (card == null)
        {
            _logger.LogInformation("Not found card: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(cardToPut, card);
            return Ok();
        }
    }
    /// <summary>
    /// Delete card by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var card = _librariesRepository.Cards.FirstOrDefault(card => card.Id == id);
        if (card == null)
        {
            _logger.LogInformation("Not found card: {id}", id);
            return NotFound();
        }
        else
        {
            _librariesRepository.Cards.Remove(card);
            return Ok();
        }
    }
}