using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
/// Controller for request
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly ILogger<RequestController> _logger;
    private readonly IRentalServiceRepository _rentalServiceRepository;
    private readonly IMapper _mapper;
    
    public RequestController(ILogger<RequestController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get information about vehicles
    /// </summary>
    /// <returns>
    /// Return list of vehicles
    /// </returns>
    [HttpGet("vehicles")]
    public IActionResult  GetVehicles()
    {
        List<Vehicle> vehicles = _rentalServiceRepository.Vehicles;

        var query = (from vehicle in vehicles
            select _mapper.Map<VehicleGetDto>(vehicle)).ToList();
        
        if (query.Count == 0)
        {
            _logger.LogInformation("Not found vehicles");
            return NotFound();
        }

        _logger.LogInformation("Get vehicles");
        return Ok(query);
    }
    
    /// <summary>
    ///     Get information about clients who took the car with the specified identifier
    /// </summary>
    /// <returns>
    /// List of clients
    /// </returns>
    [HttpGet("clients_by_model_id/{id}")]
    public IActionResult  GetClientsByModelId(ulong id)
    {
        List<Client> clients = _rentalServiceRepository.Clients;
        List<IssuedCar> issuedCars = _rentalServiceRepository.IssuedCars;
        List<Vehicle> vehicles = _rentalServiceRepository.Vehicles;

        var query = (from client in clients
            join issuedCar in issuedCars on client.Id equals issuedCar.ClientId
            join vehicle in vehicles on issuedCar.VehicleId equals vehicle.Id
            where vehicle.ModelId == id
            orderby client.LastName, client.FirstName, client.Patronymic
            select _mapper.Map<ClientGetDto>(client)).ToList();
        
        if (query.Count == 0)
        {
            _logger.LogInformation("Not found clients with this id");
            return NotFound();
        }

        _logger.LogInformation("Get clients with this id");
        return Ok(query);
    }
    
    /// <summary>
    ///     Get information about cars that are rented
    /// </summary>
    /// <returns>
    /// List of vehicles
    /// </returns>
    [HttpGet("cars_for_rent")]
    public IActionResult  GetCarsForRent()
    {
        List<IssuedCar> issuedCars = _rentalServiceRepository.IssuedCars;
        List<Vehicle> vehicles = _rentalServiceRepository.Vehicles;

        var query = (from issuedCar in issuedCars
            join vehicle in vehicles on issuedCar.VehicleId equals vehicle.Id
            where issuedCar.RefundInformationId == null
            select _mapper.Map<VehicleGetDto>(vehicle)).ToList();
        
        if (query.Count == 0)
        {
            _logger.LogInformation("Not found cars for rent");
            return NotFound();
        }

        _logger.LogInformation("Get cars for rent");
        return Ok(query);
    }
    
    /// <summary>
    ///     Get information about the top 5 most frequently rented cars
    /// </summary>
    /// <returns>
    /// List of vehicles
    /// </returns>
    [HttpGet("top_five_frequently_rented_vehicles")]
    public IActionResult  GetTopFiveFrequentlyRentedVehicles()
    {
        List<IssuedCar> issuedCars = _rentalServiceRepository.IssuedCars;
        List<Vehicle> vehicles = _rentalServiceRepository.Vehicles;
    
        foreach (IssuedCar issuedCar in issuedCars)
        {
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }
        
        var query = (from issuedCar in issuedCars
            join vehicle in vehicles on issuedCar.VehicleId equals vehicle.Id
            orderby vehicle.RentalCases.Count
            select new
        {
            number = vehicle.Number,
            modelId = vehicle.ModelId,
            colour = vehicle.Colour,
            count = vehicle.RentalCases.Count
        }).Take(5).Reverse().ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found records");
            return NotFound();
        }

        _logger.LogInformation("Get top five frequently rented vehicles");
        return Ok(query);
    }
    
    /// <summary>
    ///     Get the number of leases for each car
    /// </summary>
    /// <returns>
    /// List of vehicles and rentals count
    /// </returns>
    [HttpGet("number_of_leases_for_each_car")]
    public IActionResult  GetNumberOfCarRentals()
    {
        List<IssuedCar> issuedCars = _rentalServiceRepository.IssuedCars;
        List<Vehicle> vehicles = _rentalServiceRepository.Vehicles;

        foreach (IssuedCar issuedCar in issuedCars)
        {
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }
        
        var query = (from vehicle in vehicles
            select new
            {
                number = vehicle.Number,
                modelId = vehicle.ModelId,
                colour = vehicle.Colour,
                rentalCasesCount = vehicle.RentalCases.Count
            }).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found records");
            return NotFound();
        }

        _logger.LogInformation("Get number of car rentals");
        return Ok(query);
    }
    
    /// <summary>
    ///     Get information about rental locations where cars have been rented the maximum number of times,
    ///     arrange by name
    /// </summary>
    /// <returns>
    /// List of rental points
    /// </returns>
    [HttpGet("top_car_rental_locations")]
    public IActionResult  GetTopCarRentalLocations()
    {
        List<IssuedCar> issuedCars = _rentalServiceRepository.IssuedCars;
        List<RentalInformation> rentalInformations = _rentalServiceRepository.RentalInformations;
        List<RentalPoint> rentalPoints = _rentalServiceRepository.RentalPoints;

        var subquery = (from issuedCar in issuedCars
            join rentalInformation in rentalInformations on issuedCar.RentalInformationId equals rentalInformation.Id
            join rentalPoint in rentalPoints on rentalInformation.RentalPointId equals rentalPoint.Id
            group rentalPoint.Id by rentalPoint
            into grp
            select new
            {
                grp.Key.Title,
                grp.Key.Address,
                countOfLeases = grp.Count()
            }).ToList();

        if (subquery.Count == 0)
        {
            _logger.LogInformation("Not found rental points");
            return NotFound();
        }

        var maxNumberOfRents = subquery.Max(elem => elem.countOfLeases);

        var query = (from sq in subquery
            where sq.countOfLeases == maxNumberOfRents
            select sq).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found records");
            return NotFound();
        }

        _logger.LogInformation("Get rental points");
        return Ok(query);
    }
}

