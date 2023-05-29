using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtor;
using RealtorServer.Dto;
using RealtorServer.Repository;


namespace RealtorServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    



    private readonly ILogger<ClientController> _logger;
    private readonly IRealtorRepository _realtorRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<ClientController> logger, IRealtorRepository realtorRepository, IMapper mapper)
    {
        _logger = logger;
        _realtorRepository = realtorRepository;
        _mapper = mapper;
    }
    /*
    [HttpGet("clients-buyers")]
    public Task<ActionResult<ClientGetDto>> GetBuyersClients () {
        _logger.LogInformation("Give information about all clients looking for real estate of a given type");
        if (_context.RentRecords == null || _context.Bikes == null)
        {
            return NotFound();
        }
        var rentList = await
        (from client in _context.Clients
             join record in _context.RentRecords on client.Id equals record.ClientId
             join bike in _context.Bikes on record.BikeId equals bike.Id
             where bike.TypeId == 1
             select _mapper.Map<Client, ClientGetDto>(client)).Distinct().ToListAsync();

        var request =
            (from req in rentList
             orderby req.FullName
             select req).ToList();

        var allApplication = _fixture.FixtureApplication;
        var resultList = (from application in allApplication
                          from client in application.Clients
                          from house in application.House
                          where application.Type == "Purchase" && house.Type == "Uninhabited"
                          group client by new
                          {
                              client.Surname,
                              client.Name,
                              client.Number,
                              client.Registration,
                              client.Passport
                          } into grp
                          select new
                          {
                              grp.Key.Surname,
                              grp.Key.Name,
                              grp.Key.Number,
                              grp.Key.Registration,
                              grp.Key.Passport
                          }).ToList(); ;


        if (request.Count == 0)
        {
            _logger.LogInformation("Clients not found");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }*/

}
