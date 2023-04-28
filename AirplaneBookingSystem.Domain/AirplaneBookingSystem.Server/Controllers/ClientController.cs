using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneBookingSystem.Domain;
using AutoMapper;
using AirplaneBookingSystem.Server.Dto;

namespace AirplaneBookingSystem.Server.Controllers;
/// <summary>
/// Clients
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IDbContextFactory<AirplaneBookingSystemDbContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<AirplaneController> _logger;

    public ClientController(ILogger<AirplaneController> logger, IDbContextFactory<AirplaneBookingSystemDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for client table
    /// </summary>
    /// <returns>
    /// Return all clients
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<ClientGetDto>> GetClients()
    {
        _logger.LogInformation("Get all clients");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var clients = await ctx.Clients.ToArrayAsync();
        return _mapper.Map<IEnumerable<ClientGetDto>>(clients);
    }
    /// <summary>
    /// Get by id method for client table
    /// </summary>
    /// <param name="idClient">id client</param>
    /// <returns>Ok with ClientGetDto or NotFound</returns>
    [HttpGet("{idClient}")]
    public async Task<ActionResult<ClientGetDto>> GetClient(int idClient)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var client = await ctx.Clients.FirstOrDefaultAsync(client => client.Id == idClient);
        if (client == null)
        {
            _logger.LogInformation("Not found client : {idClient}", idClient);
            return NotFound($"The client does't exist by this id {idClient}");
        }
        else
        {
            _logger.LogInformation("Get client by {idClient}", idClient);
            return Ok(_mapper.Map<ClientGetDto>(client));
        }
    }
    /// <summary>
    /// Put method for client table
    /// </summary>
    /// <param name="idClient">An id of client which would be changed </param>
    /// <param name="clientToPut">Client class instance to insert to table</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idClient}")]
    public async Task<IActionResult> PutClient(int idClient, [FromBody] ClientPostDto clientToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var client = await ctx.Clients.FirstOrDefaultAsync(client => client.Id == idClient);
        if (client == null)
        {
            _logger.LogInformation("Not found client : {idClient}", idClient);
            return NotFound($"The client does't exist by this id {idClient}");
        }
        else
        {
            _logger.LogInformation("Update client by id {idClient}", idClient);
            _mapper.Map(clientToPut, client);
            ctx.Clients.Update(_mapper.Map<Domain.Client>(client));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Post method for client table
    /// </summary>
    /// <param name="client"> Client class instance to insert to table</param>
    /// <returns>Сreated client</returns>
    [HttpPost]
    public async Task PostClient([FromBody] ClientPostDto client)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new client");
        await ctx.Clients.AddAsync(_mapper.Map<Domain.Client>(client));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="idClient">An id of client which would be deleted</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var client = await ctx.Clients.Include(clients => clients.Tickets)
                                        .FirstOrDefaultAsync(clients => clients.Id == idClient);
        if (client == null)
        {
            _logger.LogInformation($"Not found client : {idClient}");
            return NotFound($"The client does't exist by this id {idClient}");
        }
        else
        {
            _logger.LogInformation("Delete client by id {idClient}", idClient);
            ctx.Clients.Remove(client);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
