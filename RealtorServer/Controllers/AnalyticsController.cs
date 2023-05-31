using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using Realtor;
using RealtorServer.Dto;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace RealtorServer.Controllers;
/// <summary>
/// Analytics controller for requests
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly RealtorDbContext _context;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, RealtorDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// first request - information about all clients looking for real estate of a given type
    /// </summary>
    /// <returns> List of client-buyers </returns>
    [HttpGet("clients-buyers")]
    public async Task<ActionResult<ClientGetDto>> GetBuyersClients()
    {
        _logger.LogInformation("Give information about all clients looking for real estate of a given type ");
        var buyerList = await
        (from clients in _context.Clients
         join applications in _context.Applications on clients.Id equals applications.ClientId
         join connect in _context.ApplicationHasHouses on applications.Id equals connect.ApplicationId
         join house in _context.Houses on connect.HouseId equals house.Id
         where applications.Type == "Purchase" && house.Type == "Uninhabited"
         select _mapper.Map<Realtor.Client, ClientGetDto>(clients)).Distinct().ToListAsync();

        var request =
            (from req in buyerList
             orderby req.Surname
             select req).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Clients not found");
            return NotFound();
        }
        else
        {
            return Ok(buyerList);
        }

    }
    /// <summary>
    /// second request - all sellers who left orders for a given period
    /// </summary>
    /// <returns> List of client-sellers </returns>
    [HttpGet("clients-seller")]
    public async Task<ActionResult<ClientGetDto>> GetSellersClients()
    {
        _logger.LogInformation("all sellers who left orders for a given period");
        var sellerList = await
        (from clients in _context.Clients
         join applications in _context.Applications on clients.Id equals applications.ClientId
         where applications.Data < new DateTime(2023, 02, 01) && applications.Data > new DateTime(1234, 01, 01) && applications.Type == "Sale"
         select _mapper.Map<Realtor.Client, ClientGetDto>(clients)).Distinct().ToListAsync();

        var request =
            (from req in sellerList
             orderby req.Surname
             select req).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Clients not found");
            return NotFound();
        }
        else
        {
            return Ok(sellerList);
        }
    }
    /// <summary>
    /// third request - information about sellers and real estate objects that correspond to a specific buyer's request
    /// </summary>
    /// /// <returns> List of client-sellers </returns>
    [HttpGet("seller-object")]
    public async Task<ActionResult<ClientGetDto>> GetSellerObject()
    {
        _logger.LogInformation("all sellers who left orders for a given period");
        var sellerObjectList = await
        (from clients in _context.Clients
         join applications in _context.Applications on clients.Id equals applications.ClientId
         join connect in _context.ApplicationHasHouses on applications.Id equals connect.ApplicationId
         join house in _context.Houses on connect.HouseId equals house.Id
         where applications.Type == "Sale" && applications.Cost == 1
         select new
         {
             clients.Surname,
             clients.Name,
             clients.Number,
             clients.Registration,
             clients.Passport,
             house.Type,
             house.Square,
             house.Rooms,
             house.Address
         }).ToListAsync();
        return Ok(sellerObjectList);
    }
    /// <summary>
    /// fourth request - information about the number of applications for each type of property    
    /// </summary>
    /// <returns> list with count of applications for each type of property</returns>
    [HttpGet("count application")]
    public async Task<ActionResult<ClientGetDto>> GetCountApplication()
    {
        _logger.LogInformation("all sellers who left orders for a given period");        
         var listUninhabited = await
            (from applications in _context.Applications
             join connect in _context.ApplicationHasHouses on applications.Id equals connect.ApplicationId
             join house in _context.Houses on connect.HouseId equals house.Id
             where house.Type == "Uninhabited"
             select applications).ToListAsync();
        var counterUninhabited = listUninhabited.Count;
        var listResidential = await
            (from applications in _context.Applications
             join connect in _context.ApplicationHasHouses on applications.Id equals connect.ApplicationId
             join house in _context.Houses on connect.HouseId equals house.Id
             where house.Type == "Residential"
             select applications).ToListAsync();
        var countResidential = listResidential.Count;
        return Ok(new { counterUninhabited , countResidential });        
    }
    /// <summary>
    /// fifth request - Display the top 5 clients by the number of applications
    /// </summary>
    /// <returns> List of the top 5 clients </returns>
    [HttpGet("topClients")]
    public async Task<ActionResult<ClientGetDto>> GetTopClients()
    {
        _logger.LogInformation("top 5 clients by the number of applications");
        var listSale = await
            (from clien in _context.Clients
             join applications in _context.Applications on clien.Id equals applications.ClientId
             where applications.Type == "Sale"
             group clien by new
             {
                 clien.Surname,
                 clien.Name,
                 clien.Applications.Count
             } into grp
             select new
             {
                 grp.Key.Surname,
                 grp.Key.Name,
                 grp.Key.Count
             }).ToListAsync();
        var result2 = (from client in listSale
                       orderby listSale.Count descending
                       select client).Take(5).ToList();
        var listPurchase = await
            (from clien in _context.Clients
             join applications in _context.Applications on clien.Id equals applications.ClientId
             where applications.Type == "Purchase"
             group clien by new
             {
                 clien.Surname,
                 clien.Name,
                 clien.Applications.Count
             } into grp
             select new
             {
                 grp.Key.Surname,
                 grp.Key.Name,
                 grp.Key.Count
             }).ToListAsync();
        var result1 = (from client in listPurchase
                       orderby listPurchase.Count descending
                       select client).Take(5).ToList();
        return Ok(new { result1, result2 });        
    }

    /// <summary>
    /// sixth request - information about clients who opened orders with the minimum cost    
    /// </summary>
    /// <returns> List information about client with min cost application </returns>
    [HttpGet("clients-minApplicationCost")]
    public async Task<ActionResult<ClientGetDto>> GetMinCost()
    {
        _logger.LogInformation("information about clients who opened orders with the minimum cost");
        var sellerList = await
        (from clients in _context.Clients
         join applications in _context.Applications on clients.Id equals applications.ClientId
         group clients by new
         {
             clients.Surname,
             clients.Name,
             clients.Number,
             clients.Registration,
             clients.Passport,
             applications.Cost
         } into grp
         select new
         {
             grp.Key.Surname,
             grp.Key.Name,
             grp.Key.Number,
             grp.Key.Registration,
             grp.Key.Passport,
             grp.Key.Cost
         }).ToListAsync();

        var result1 = (from client in sellerList
                       orderby client.Cost
                       select client).Take(1).ToList();
        return Ok(result1);       
    }
}
