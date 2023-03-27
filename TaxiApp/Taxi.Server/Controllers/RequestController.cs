using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Server.Repository;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server.Controllers;

public class RequestController: ControllerBase
{
    private readonly ILogger<RequestController> _logger;
    private readonly ITaxiRepository _taxiRepository;
    private readonly IMapper _mapper;
    
    public RequestController(ILogger<RequestController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }
    
    [HttpGet("vehicles_and_drivers/{id}")]
    public IActionResult GetVehicleAndDriver(ulong id)
    {
        var query = (from vehicle in _taxiRepository.Vehicles
            from vehicleClassification in _taxiRepository.VehicleClassifications
            from driver in _taxiRepository.Drivers
            where vehicleClassification.Id == vehicle.VehicleClassificationId &&
                  driver.Id == vehicle.DriverId && driver.Id == id
            select new
            {
                vehicle.RegistrationCarPlate,
                vehicle.Colour,
                driver.FirstName,
                driver.LastName,
                driver.Patronymic,
                driver.PhoneNumber,
                driver.Passport,
                vehicleClassification.Brand,
                vehicleClassification.Model,
                vehicleClassification.Class
            }).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found driver and vehicle by driver id");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get driver and vehicle by driver id");
            return Ok(query);
        }
    }

    [HttpGet("passengers_over_given_period")]
    public ActionResult<IEnumerable<PassengerGetDto>> GetPassengerOverGivenPeriod(DateTime minDate, DateTime maxDate)
    {
        var passengers = _taxiRepository.Passengers;
        var rides = _taxiRepository.Rides;
        foreach (var ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }
        
        var query = (from passenger in passengers
            from ride in passenger.Rides
            where ride.RideDate <= maxDate && ride.RideDate >= minDate
            orderby passenger.LastName, passenger.FirstName, passenger.Patronymic
            select _mapper.Map<PassengerGetDto>(passenger)).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found passengers over given period");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get passengers over given period");
            return Ok(query);
        }
    }
    
    [HttpGet("count_passenger_rides")]
    public IActionResult GetCountPassengerRides()
    {
        var passengers = _taxiRepository.Passengers;
        var rides = _taxiRepository.Rides;
        foreach (var ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }

        var query = (from passenger in passengers
            select new
            {
                passenger.LastName,
                passenger.FirstName,
                passenger.Patronymic,
                passenger.Rides.Count
            }).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found passengers");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get count passenger rides");
            return Ok(query);
        }
        
        
    }

    [HttpGet("count_top_driver_rides")]
    public IEnumerable<Driver> GetTopDriver()
    {
        var vehicles = _taxiRepository.Vehicles;
        var rides = _taxiRepository.Rides;
        var drivers = _taxiRepository.Drivers;
        foreach (var ride in rides)
        {
            vehicles[(int)ride.VehicleId - 1].Rides.Add(ride);
        }

        var query = (from vehicle in vehicles
            from driver in drivers
            where vehicle.DriverId == driver.Id
            orderby vehicle.Rides.Count
            select driver).Take(2).ToList();
        
        _logger.LogInformation("Get top 2 driver by count of rides");
        return query;
    }

    [HttpGet("infos_about_rides")]
    public IActionResult GetInfosAboutRides()
    {
        var vehicles = _taxiRepository.Vehicles;
        var rides = _taxiRepository.Rides;
        var drivers = _taxiRepository.Drivers;
        foreach (var ride in rides)
        {
            vehicles[(int)ride.VehicleId - 1].Rides.Add(ride);
        }

        var query = (from ridesInfo in from ride in rides
                group ride by ride.VehicleId
                into grp
                select new
                {
                    vehicleId = grp.Key,
                    count = grp.Count(),
                    avg = grp.Average(ride =>
                        ride.RideTime.Seconds + (60 * ride.RideTime.Minutes) + (3600 * ride.RideTime.Hours)),
                    max = grp.Max(ride =>
                        ride.RideTime.Seconds + (60 * ride.RideTime.Minutes) + (3600 * ride.RideTime.Hours))
                }
            from driver in drivers
            where driver.Id == ridesInfo.vehicleId
            select new
            {
                driver.LastName,
                driver.FirstName,
                driver.Patronymic,
                ridesInfo.count,
                ridesInfo.avg,
                ridesInfo.max
            }).ToList();
        
        _logger.LogInformation("Get infos about passengers rides");
        return Ok(query);
    }
    
    [HttpGet("max_rides_of_passenger")]
    public IActionResult GetMaxRidesOfPassenger(DateTime minDate, DateTime maxDate)
    {
        var passengers = _taxiRepository.Passengers;
        var rides = _taxiRepository.Rides;
        foreach (var ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }
        
        var subquery = (from passenger in passengers
            from ride in passenger.Rides
            where ride.RideDate < maxDate && ride.RideDate > minDate
            group passenger.Id by passenger
            into grp
            select new
            {
                grp.Key.Id,
                grp.Key.LastName,
                grp.Key.FirstName,
                grp.Key.Patronymic,
                grp.Key.PhoneNumber,
                count = grp.Count()
            }).ToList();

        if (subquery.Count == 0)
        {
            _logger.LogInformation("Not found passengers");
            return NotFound();
        }

        var max = subquery.Max(elem => elem.count);

        var query = (from sq in subquery
            where sq.count == max
            select new
            {
                sq.Id,
                sq.LastName,
                sq.FirstName,
                sq.Patronymic,
                sq.PhoneNumber
            }).ToList();
        
        _logger.LogInformation("Get passenger with max count of rides");
        return Ok(query);
    }
}