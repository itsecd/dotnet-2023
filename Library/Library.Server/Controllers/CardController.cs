using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Controllers;
/// <summary>
/// Card controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Card controller's constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public CardController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all cards
    /// </summary>
    /// <returns> List of all cards </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CardGetDto>>> GetCards()
    {
        return await _mapper.ProjectTo<CardGetDto>(_context.Cards).ToListAsync();
    }
    /// <summary>
    /// Return info about card by id
    /// </summary>
    /// <param name="id"> Card's id </param>
    /// <returns> Card by id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CardGetDto>> GetCard(int id)
    {
        var card = await _context.Cards.FindAsync(id);

        if (card == null)
        {
            return NotFound();
        }

        return _mapper.Map<CardGetDto>(card);
    }
    /// <summary>
    /// Add a new card
    /// </summary>
    /// <param name="card"> New cards object </param>
    /// <returns> Inserted card </returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<CardGetDto>> PostCard(CardPostDto card)
    {
        var mappedCard = _mapper.Map<Card>(card);

        _context.Cards.Add(mappedCard);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostCard", new { id = mappedCard.Id }, _mapper.Map<CardGetDto>(mappedCard));
    }
    /// <summary>
    /// Сhange info of selected card
    /// </summary>
    /// <param name="id"> Card's id </param>
    /// <param name="card"> New cards object </param>
    /// <returns> NoContent </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCard(int id, CardPostDto card)
    {
        var cardToModify = await _context.Cards.FindAsync(id);
        if (cardToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(card, cardToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Delete card by id
    /// </summary>
    /// <param name="id"> Card's id </param>
    /// <returns> NoContent </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(int id)
    {
        var card = await _context.Cards.FindAsync(id);
        if (card == null)
        {
            return NotFound();
        }

        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}